import 'package:flutter/material.dart';
import 'package:my_bank/api/cadastro_api.dart';
import 'package:my_bank/layout/colors_layout.dart';

class CadastroPage extends StatelessWidget {
  final _ctrlNome = TextEditingController();
  final _ctrlCPF = TextEditingController();
  final _ctrlDataNascimento = TextEditingController();
  final _ctrlSenha = TextEditingController();
  final _ctrlSenhaConfirma = TextEditingController();
  final _formKey = GlobalKey<FormState>();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Cadastro"),
        backgroundColor: ColorsLayout.primaryColor(),
      ),
      body: Form(
          key: _formKey,
          child: ListView(
            children: [
              Padding(
                padding: const EdgeInsets.all(8.0),
                child: _textFormField("Nome", "Digite seu nome",
                    controller: _ctrlNome),
              ),
              Padding(
                padding: const EdgeInsets.all(8.0),
                child: _textFormField("CPF", "Digite seu CPF.",
                    controller: _ctrlCPF),
              ),
              Padding(
                padding: const EdgeInsets.all(8.0),
                child: _textFormField(
                    "Data de Nascimento", "Digite sua data de nascimento.",
                    controller: _ctrlDataNascimento),
              ),
              Padding(
                padding: const EdgeInsets.all(8.0),
                child: _textFormField("Senha", "Digite sua senha.",
                    controller: _ctrlSenha),
              ),
              Padding(
                padding: const EdgeInsets.all(8.0),
                child: _textFormField(
                    "Confirmar senha", "Digite novamente a senha",
                    controller: _ctrlSenhaConfirma),
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
            ],
          )),
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
    if (_ctrlSenha.text == _ctrlSenhaConfirma.text) {
      await CadastroApi.cadastro(_ctrlNome.text, _ctrlCPF.text,
          _ctrlDataNascimento.text, _ctrlSenha.text);
      Navigator.pop(context);
    }
  }
}
