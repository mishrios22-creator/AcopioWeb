<%@ Page Title="Ingresar"
    Language="VB"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="false"
    CodeBehind="Ingresar.aspx.vb"
    Inherits="AcopioWeb.Ingresar" %>

<asp:Content ID="Contenido"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <div class="card shadow-sm mx-auto" style="max-width:460px">
        <div class="card-body p-4">

            <h1 class="h3 mb-4">Ingresar</h1>

            <asp:ValidationSummary
                runat="server"
                ValidationGroup="Login"
                CssClass="text-danger" />

            <div class="mb-3">
                <asp:Label runat="server"
                    AssociatedControlID="txtCorreo"
                    Text="Correo" />

                <asp:TextBox ID="txtCorreo"
                    runat="server"
                    TextMode="Email"
                    CssClass="form-control" />

                <asp:RequiredFieldValidator
                    runat="server"
                    ControlToValidate="txtCorreo"
                    ValidationGroup="Login"
                    ErrorMessage="Ingrese el correo."
                    Display="None" />
            </div>

            <div class="mb-3">
                <asp:Label runat="server"
                    AssociatedControlID="txtClave"
                    Text="Contraseña" />

                <asp:TextBox ID="txtClave"
                    runat="server"
                    TextMode="Password"
                    CssClass="form-control" />

                <asp:RequiredFieldValidator
                    runat="server"
                    ControlToValidate="txtClave"
                    ValidationGroup="Login"
                    ErrorMessage="Ingrese la contraseña."
                    Display="None" />
            </div>

            <asp:Button ID="btnIngresar"
                runat="server"
                Text="Ingresar"
                ValidationGroup="Login"
                CssClass="btn btn-success"
                OnClick="btnIngresar_Click" />

            <asp:Label ID="lblError"
                runat="server"
                CssClass="text-danger d-block mt-3" />

        </div>
    </div>

</asp:Content>
