import 'package:flutter/material.dart';
import 'package:my_bank/api/home_api.dart';
import 'package:my_bank/api/login_api.dart';
import 'package:my_bank/layout/colors_layout.dart';
import 'package:my_bank/pages/cadastro_page.dart';
import 'package:my_bank/pages/home_page.dart';

class LoginPage extends StatelessWidget {
  final _ctrlLogin = TextEditingController();
  final _ctrlSenha = TextEditingController();
  final _formKey = GlobalKey<FormState>();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Acesso ao MyBank"),
        backgroundColor: ColorsLayout.primaryColor(),
      ),
      body: Container(
        child: Form(
            key: _formKey,
            child: ListView(
              children: [
                Padding(
                  padding: const EdgeInsets.all(8.0),
                  child: _textFormField("CPF", "Digite o seu CPF",
                      controller: _ctrlLogin),
                ),
                Padding(
                  padding: const EdgeInsets.all(8.0),
                  child: _textFormField(
                    "Senha",
                    "Digite a Senha",
                    senha: true,
                    controller: _ctrlSenha,
                  ),
                ),
                Padding(
                  padding: const EdgeInsets.fromLTRB(64.0, 8.0, 64.0, 8.0),
                  child: ElevatedButton(
                    style: ButtonStyle(
                      shape: MaterialStateProperty.all<RoundedRectangleBorder>(
                          RoundedRectangleBorder(
                              borderRadius: BorderRadius.circular(18.0),
                              side: BorderSide(
                                  color: ColorsLayout.primaryColor()))),
                      backgroundColor:
                          MaterialStateProperty.all<Color>(Colors.white),
                    ),
                    onPressed: () => _clickButton(context),
                    child: Text(
                      "Login",
                      style: TextStyle(color: ColorsLayout.primaryColor()),
                    ),
                  ),
                ),
                Padding(
                  padding: const EdgeInsets.fromLTRB(64.0, 8.0, 64.0, 8.0),
                  child: GestureDetector(
                    onTap: () => _clickCadastro(context),
                    child: Center(
                      child: Text(
                        "Cadastre-se no MyBank",
                        style: TextStyle(
                            fontWeight: FontWeight.bold,
                            color: ColorsLayout.primaryColor()),
                      ),
                    ),
                  ),
                ),
              ],
            )),
      ),
    );
  }

  _textFormField(
    String label,
    String hint, {
    bool senha = false,
    TextEditingController controller,
    FormFieldValidator<String> validator,
  }) {
    return TextFormField(
      controller: controller,
      validator: validator,
      obscureText: senha,
      decoration: InputDecoration(
        labelText: label,
        hintText: hint,
      ),
    );
  }

  _clickButton(BuildContext context) async {
    if (!_formKey.currentState.validate()) {
      return;
    }
    String login = _ctrlLogin.text;
    String senha = _ctrlSenha.text;

    var response = await LoginApi.login(login, senha);

    if (response != null) {
      Navigator.push(
          context, MaterialPageRoute(builder: (context) => HomePage(response)));
    }
  }

  _clickCadastro(BuildContext context) {
    Navigator.push(
        context, MaterialPageRoute(builder: (context) => CadastroPage()));
  }
}
