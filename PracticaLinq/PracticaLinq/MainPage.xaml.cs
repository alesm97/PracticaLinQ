using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PracticaLinq
{
    public partial class MainPage : ContentPage
    {
        List<Contacto> contactos = new List<Contacto>();
        List<Contacto> contactosResult = new List<Contacto>();

        public MainPage()
        {
            InitializeComponent();
            loadFile();
        }

        /// <summary>
        /// Lee el archivo .XML y lo pasa al listview.
        /// </summary>
        private void loadFile()
        {
            contactos = resources.Leer.LeerArchivoXML("PracticaLinq.data.Info.xml");
            listContactos.ItemsSource = contactos;
        }

        /// <summary>
        /// Llama al método where de LinQ y lo pasa a la listview.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadWhere(object sender, EventArgs e)
        {
            lblError.Text = "";

            if (!string.IsNullOrEmpty(txtName.Text))
            {
                var personasEnumerable = contactos.Where(p => p.nombre.Contains(txtName.Text));
                contactosResult = personasEnumerable.ToList();
                if(contactosResult.Count != 0)
                {
                    listContactos.ItemsSource = contactosResult;
                }
                else
                {
                    listContactos.ItemsSource = contactosResult;
                    lblError.Text = "No hay registros que coincidan";
                }
            }
            else
            {
                lblError.Text = "Debe introducir el nombre.";
            }
        }

        /// <summary>
        /// Llama al método firstordefault de LinQ y lo pasa a la listview.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadFirst(object sender, EventArgs e)
        {
            int age;

            lblError.Text = "";

            if (!string.IsNullOrEmpty(txtAge.Text))
            { 
                if(int.TryParse(txtAge.Text, out age))
                {
                    var personaFirstExiste = contactos.FirstOrDefault(p => p.edad >= age);
                    if (personaFirstExiste != null)
                    {
                        contactosResult.Clear();
                        contactosResult.Add(personaFirstExiste);
                        listContactos.ItemsSource = contactosResult;
                    }
                    else
                    {
                        contactosResult.Clear();
                        listContactos.ItemsSource = contactosResult;
                        lblError.Text = "No hay registros que coincidan";
                    }
                }
                else
                {
                    lblError.Text = "Debe introducir números válidos.";
                }
            }
            else
            {
                lblError.Text = "Debe introducir la edad.";
            }
        }

        /// <summary>
        /// Llama al método singleordefault de LinQ y lo pasa a la listview.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadSingle(object sender, EventArgs e)
        {
            int age;

            lblError.Text = "";

            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtAge.Text))
            {
                if (int.TryParse(txtAge.Text, out age))
                {
                    var personaFirstExiste = contactos.Where(p => p.nombre == txtName.Text).SingleOrDefault(p => p.edad >= age);

                    if (personaFirstExiste != null)
                    {
                        contactosResult.Clear();
                        contactosResult.Add(personaFirstExiste);
                        listContactos.ItemsSource = contactosResult;
                    }
                    else
                    {
                        contactosResult.Clear();
                        listContactos.ItemsSource = contactosResult;
                        lblError.Text = "No hay registros que coincidan";
                    }
                }
                else
                {
                    lblError.Text = "Debe introducir números válidos.";
                }
            }
            else
            {
                lblError.Text = "Debe introducir nombre y edad.";
            }

        }

        /// <summary>
        /// Llama al método lastordefault de LinQ y lo pasa a la listview.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadLast(object sender, EventArgs e)
        {
            int age;

            lblError.Text = "";

            if (!string.IsNullOrEmpty(txtAge.Text))
            {

                if (int.TryParse(txtAge.Text, out age))
                {
                    var personaFirstExiste = contactos.LastOrDefault(p => p.edad >= age);
                    if (personaFirstExiste != null)
                    {
                        contactosResult.Clear();
                        contactosResult.Add(personaFirstExiste);
                        listContactos.ItemsSource = contactosResult;
                    }
                    else
                    {
                        contactosResult.Clear();
                        listContactos.ItemsSource = contactosResult;
                        lblError.Text = "No hay registros que coincidan";
                    }
                }
            }
            else
            {
                lblError.Text = "Debe introducir la edad.";
            }
        }

        /// <summary>
        /// Llama al método orderby de LinQ y lo pasa a la listview.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadOrder(object sender, EventArgs e)
        {
            lblError.Text = "";

            var personasEnumerable = contactos.OrderBy(p => p.nombre);
            contactosResult = personasEnumerable.ToList();
            if (contactosResult.Count != 0)
            {
                listContactos.ItemsSource = contactosResult;
            }
            else
            {
                listContactos.ItemsSource = contactosResult;
                lblError.Text = "No hay registros que coincidan";
            }            
        }

        /// <summary>
        /// Llama al método orderbydescending de LinQ y lo pasa a la listview.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadOrderDes(object sender, EventArgs e)
        {
            lblError.Text = "";

            var personasEnumerable = contactos.OrderByDescending(p => p.nombre);
            contactosResult = personasEnumerable.ToList();
            if (contactosResult.Count != 0)
            {
                listContactos.ItemsSource = contactosResult;
            }
            else
            {
                listContactos.ItemsSource = contactosResult;
                lblError.Text = "No hay registros que coincidan";
            }
        }

        /// <summary>
        /// Llama al método skipwhile de LinQ y lo pasa a la listview.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadSkip(object sender, EventArgs e)
        {
            int age;

            lblError.Text = "";

            if (!string.IsNullOrEmpty(txtAge.Text))
            {
                if (int.TryParse(txtAge.Text, out age))
                {
                    var personasEnumerable = contactos.SkipWhile(p => p.edad <= age);
                    contactosResult = personasEnumerable.ToList();

                    if (contactosResult.Count != 0)
                    {
                        listContactos.ItemsSource = contactosResult;
                    }
                    else
                    {
                        listContactos.ItemsSource = contactosResult;
                        lblError.Text = "No hay registros que coincidan";
                    }
                }
                else
                {
                    lblError.Text = "Debe introducir números válidos.";
                }
            }
            else
            {
                lblError.Text = "Debe introducir la edad.";
            }

        }

        /// <summary>
        /// Llama al método takewhile de LinQ y lo pasa a la listview.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadTake(object sender, EventArgs e)
        {
            int age;

            lblError.Text = "";

            if (!string.IsNullOrEmpty(txtAge.Text))
            {
                if(int.TryParse(txtAge.Text, out age))
                {
                    var personasEnumerable = contactos.TakeWhile(p => p.edad <= age);
                    contactosResult = personasEnumerable.ToList();

                    if (contactosResult.Count != 0)
                    {
                        listContactos.ItemsSource = contactosResult;
                    }
                    else
                    {
                        listContactos.ItemsSource = contactosResult;
                        lblError.Text = "No hay registros que coincidan";
                    }
                }
                else
                {
                    lblError.Text = "Debe introducir números válidos.";
                }                
            }
            else
            {
                lblError.Text = "Debe introducir la edad.";
            }
        }
    }
}