using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pr_web
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                CargarPizzas();
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            string nombre = txtName.Text;
            string tamanio = PizzaSize.SelectedValue;
            decimal precio = Convert.ToDecimal(txtPrice.Text);
            bool gluten_checked = Convert.ToBoolean(IsGlutenFree.SelectedValue);

            Pizza nuevaPizza = new Pizza();

            nuevaPizza.CrearPizza(nombre, precio, tamanio, gluten_checked);

            CargarPizzas();
            LimpiarControles();

        }

        private void CargarPizzas()
        {
            Pizza pizza = new Pizza();
            DataTable dtPizzas = pizza.ListarPizzas();

            if (dtPizzas != null && dtPizzas.Rows.Count > 0)
            {
                grid_pizzas.DataSource = dtPizzas;
                grid_pizzas.DataBind();
            }
        }

        protected void btnVer_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int  pizzaSeleccionadaID = Convert.ToInt32(grid_pizzas.DataKeys[row.RowIndex]["id"]);
            Session["PizzaSeleccionadaID"] = pizzaSeleccionadaID;

            txtName.Text = row.Cells[2].Text; // 2 es el índice de la columna "nombre"
            string tamanio = row.Cells[3].Text; // 3 es el índice de la columna "tamanio"
            PizzaSize.SelectedValue = tamanio;

            string glutenCheckedValue = (row.Cells[4].Controls[0] as DataBoundLiteralControl).Text.Trim();
            if (glutenCheckedValue == "Sí")
            {
                IsGlutenFree.SelectedValue = "true";
            }
            else if (glutenCheckedValue == "No")
            {
                IsGlutenFree.SelectedValue = "false";
            }
            txtPrice.Text = row.Cells[5].Text; // 5 es el índice de la columna "precio"
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int idPizza = Convert.ToInt32(grid_pizzas.DataKeys[row.RowIndex]["id"]);

            lbl_mensaje.Text="Se va a eliminar la pizza con ID: " + idPizza;
            Pizza pizza = new Pizza();
            pizza.EliminarPizza(idPizza);
            CargarPizzas();
            LimpiarControles();

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {

            if (Session["PizzaSeleccionadaID"] != null)
            {
                int pizzaSeleccionadaID = (int)Session["PizzaSeleccionadaID"];

                // Se obtienen los datos de la pizza desde los controles
                string nombre = txtName.Text;
                string tamanio = PizzaSize.SelectedValue;
                decimal precio = Convert.ToDecimal(txtPrice.Text);
                bool gluten_checked = Convert.ToBoolean(IsGlutenFree.SelectedValue);

                // Llamada al método para actualizar la pizza
                Pizza pizza = new Pizza();
                pizza.ActualizarPizza(nombre, precio, tamanio, gluten_checked, pizzaSeleccionadaID);

                // Limpia la variable de sesión
                Session["PizzaSeleccionadaID"] = null;

                // Limpia los controles de entrada
                LimpiarControles();

                // Recarga la lista de pizzas
                CargarPizzas();
            }
            else
            {
                lbl_mensaje.Text = "Primero selecciona una pizza para actualizar.";
            }
        }

        private void LimpiarControles()
        {
            txtName.Text = string.Empty;
            PizzaSize.SelectedIndex = 0; // Esto seleccionará el primer elemento en el DropDownList
            IsGlutenFree.ClearSelection(); // Esto deseleccionará todos los elementos
            txtPrice.Text = string.Empty;
            lbl_mensaje.Text = string.Empty;
        }

    }
}