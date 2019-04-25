using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CDSTabIndexPackage.CDSTabIndex;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

namespace CDSTabIndex
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class TabIndexCommand
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0100;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("7e243fb4-0258-4660-ab00-74cd516f9dec");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly AsyncPackage package;

        // Local Variables
        List<ControlesLista> lstControle;
        Control FormAtivo;
        frmTabIndex frmTabIndex;
        DataTable tbControle;
        static DTE dte;

        /// <summary>
        /// Initializes a new instance of the <see cref="TabIndexCommand"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="commandService">Command service to add command to, not null.</param>
        private TabIndexCommand(AsyncPackage package, OleMenuCommandService commandService)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new MenuCommand(this.Execute, menuCommandID);
            commandService.AddCommand(menuItem);
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static TabIndexCommand Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static async Task InitializeAsync(AsyncPackage package)
        {
            // Switch to the main thread - the call to AddCommand in TabIndexCommand's constructor requires
            // the UI thread.
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            OleMenuCommandService commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
            Instance = new TabIndexCommand(package, commandService);

            dte = await package.GetServiceAsync(typeof(SDTE)) as DTE;

        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void Execute(object sender, EventArgs e)
        {
            // Show a Message Box to prove we were here
            Guid clsid = Guid.Empty;

            EnvDTE.Window objWindow;
            IDesignerHost objIDesignerHost;
            System.IServiceProvider objIServiceProvider;
            //IComponent objIComponent;

            PropertyDescriptorCollection colPropertyDescriptorCollection;
            PropertyDescriptor objPropertyDescriptor;
            IContainer objIContainer;

            var doc = dte.ActiveDocument;

            if (doc == null)
            {
                MessageBox.Show("There are no Windows Forms active.", "CDS TabIndex Designer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            objWindow = doc.ActiveWindow;
            if (objWindow.Caption.IndexOf("]") == -1 && objWindow.Caption.IndexOf("]") == -1)
            {
                MessageBox.Show("Form is not in Design Mode.", "CDS TabIndex Designer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            objIDesignerHost = (IDesignerHost)objWindow.Object;
            objIServiceProvider = (System.IServiceProvider)objIDesignerHost;
            objIContainer = objIDesignerHost.Container;

            string ControleName;

            lstControle = new List<ControlesLista>();
            frmTabIndex = new frmTabIndex();
            frmTabIndex.Evento += EventoSeleciona;

            // tabela para armazenar os dados dos controles e mostrar a tela.
            tbControle = new DataTable("Controle");
            tbControle.Columns.Add(new DataColumn("Nome", Type.GetType("System.String")));
            tbControle.Columns.Add(new DataColumn("Posicao", Type.GetType("System.String")));


            foreach (IComponent objIComponent in objIContainer.Components)
            {
                if (objIComponent.GetType().Name == "Form")
                {
                    FormAtivo = ((Control)objIComponent);
                }
                if (objIComponent.GetType().Name == "Panel" || objIComponent.GetType().Name == "GroupBox" || objIComponent.GetType().Name == "TabPage")
                {
                    colPropertyDescriptorCollection = TypeDescriptor.GetProperties(objIComponent);
                    // Pega nome do controle
                    objPropertyDescriptor = colPropertyDescriptorCollection["Name"];
                    // Pega nome do controle
                    ControleName = objPropertyDescriptor.GetValue(objIComponent).ToString();
                    lstControle.Add(new ControlesLista() { Componente = objIComponent, Propriedade = colPropertyDescriptorCollection, Nome = ControleName, TabIndex = "" });
                }
                if (objIComponent.GetType().Name != "Form" && objIComponent.GetType().Name != "TabControl") // && objIComponent.GetType().Name != "UserControl")
                {
                    if (objIComponent is Control)
                    {
                        if (((Control)objIComponent).TabStop == true)
                        {
                            colPropertyDescriptorCollection = TypeDescriptor.GetProperties(objIComponent);
                            // Pega nome do controle
                            objPropertyDescriptor = colPropertyDescriptorCollection["Name"];
                            // Pega nome do controle
                            ControleName = objPropertyDescriptor.GetValue(objIComponent).ToString();
                            lstControle.Add(new ControlesLista() { Componente = objIComponent, Propriedade = colPropertyDescriptorCollection, Nome = ControleName, TabIndex = "" });
                        }
                    }
                }
            }

            // Ajusta os nomes para criar hierarquia dos componentes
            Control ctl;
            int w = 0;
            try
            {
                for (int c = 0; c < lstControle.Count; c++)
                {
                    w = c;
                    ctl = (Control)lstControle[c].Componente;
                    if (ctl.Parent == null)
                    {
                        break;
                    }
                    do
                    {
                        if (ctl.Parent.GetType().Name != "Form" && ctl.Parent.GetType().Name != "TabControl")
                        {
                            if (ctl.Parent.Name != "")
                            {
                                lstControle[c].NomePai = ctl.Parent.Name + ": " + lstControle[c].NomePai;
                            }
                        }
                        if (ctl.GetType().Name == "TabPage" || ctl.Parent.GetType().Name == "TabPage")
                        {
                            lstControle[c].ComponenteTabPage = ctl;
                        }
                        lstControle[c].TabIndex = ctl.TabIndex.ToString("000") + "." + lstControle[c].TabIndex;
                        ctl = ctl.Parent;
                    } while (ctl.Parent != null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }


            // ordena controle pelo TabIndex
            lstControle.Sort(delegate (ControlesLista c1, ControlesLista c2)
            {
                return c1.TabIndex.CompareTo(c2.TabIndex);
            });

            for (int c = 0; c < lstControle.Count; c++)
            {
                ctl = (Control)lstControle[c].Componente;
                if (ctl.GetType().Name == "Form" || ctl.GetType().Name == "TabControl" || ctl.GetType().Name == "TabPage")
                {
                    continue;
                }
                //if (lstControle[c].NomePai.IndexOf(": : : ") != -1)
                //{
                //    lstControle[c].NomePai = lstControle[c].NomePai.Replace(
                //}


                DataRow linha = tbControle.NewRow();
                linha["Nome"] = lstControle[c].NomePai + lstControle[c].Nome;
                linha["Posicao"] = c.ToString();
                tbControle.Rows.Add(linha);
            }

            frmTabIndex.tbControle = tbControle;
            frmTabIndex.ShowDialog();

            if (FormAtivo != null) // faz um refresh no form
            {
                FormAtivo.Refresh();
            }

            // Aplica mudanças no TabOrder
            if (frmTabIndex.Aplicar)
            {
                int Tab = 0;
                ControlesLista prop;
                foreach (DataRow linha in tbControle.Rows)
                {
                    prop = lstControle[int.Parse(linha["Posicao"].ToString())];
                    IComponent objIComponent = prop.Componente;
                    ctl = (Control)objIComponent;

                    if (ctl.GetType().Name == "Form" || ctl.GetType().Name == "TabControl" || ctl.GetType().Name == "TabPage")
                    {
                        continue;
                    }
                    objPropertyDescriptor = prop.Propriedade["TabIndex"];
                    objPropertyDescriptor.SetValue(objIComponent, Tab);
                    Tab++;
                }
            }
            tbControle.Clear();
            frmTabIndex.Dispose();
            return;
        }


        // Seleciona o controle no form e desenha um quadro em volta
        private void EventoSeleciona(object sender, EventArgs e)
        {
            FormAtivo.Refresh();
            ControlesLista prop = lstControle[frmTabIndex.ControleAtual];
            {
                IComponent objIComponent = prop.Componente;
                Control c = ((Control)objIComponent);

                if (prop.ComponenteTabPage != null) // coloca o Foco no TabPage, caso exista
                {
                    TabPage tab = (TabPage)prop.ComponenteTabPage;
                    TabControl tabc = (TabControl)tab.Parent;
                    tabc.SelectedTab = tab;
                    tab.Refresh();
                }
                if (c.GetType().Name != "TabPage" && c.Parent != null) // se não for TabPage, pinta um quadrado em volta do controle
                {
                    Pen p = new Pen(Color.Blue);
                    p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    p.Width = 1;
                    Graphics g = Graphics.FromHwnd(c.Parent.Handle);
                    g.DrawRectangle(p, c.Left - 1, c.Top - 1, c.Width + 1, c.Height + 1);
                }
            }
        }
    }
}
