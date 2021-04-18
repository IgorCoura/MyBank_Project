import 'package:flutter/material.dart';
import 'package:my_bank/api/conta_api.dart';
import 'package:my_bank/layout/colors_layout.dart';

class OptionsContaWidget extends StatelessWidget {
  final int options;
  final Function(int) _alteraOptions;
  final Function _atualizarHome;
  final Map _data;
  final String _token;

  OptionsContaWidget(this.options, this._alteraOptions, this._data, this._token,
      this._atualizarHome);

  @override
  Widget build(BuildContext context) {
    var widthScreen = MediaQuery.of(context).size.width;
    var heigthScreen = MediaQuery.of(context).size.height;
    return options > 0 && options < 5
        ? Center(
            child: Container(
              height: heigthScreen,
              width: widthScreen,
              color: ColorsLayout.backgroundColor(opacity: 0.8),
              child: Stack(
                children: [
                  Center(
                    child: Container(
                        height: widthScreen / 1.5,
                        width: widthScreen / 1.5,
                        color: ColorsLayout.primaryColor(),
                        child: options == 4
                            ? _deletar(context)
                            : options == 3
                                ? _transferir(context)
                                : options == 2
                                    ? _sacar(context)
                                    : options == 1
                                        ? _depositar(context)
                                        : Container()),
                  ),
                ],
              ),
            ),
          )
        : Container();
  }

  _deletar(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.center,
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        Text(
          "Deseja excluir essa conta?",
          style: TextStyle(color: Colors.white, fontSize: 20),
        ),
        Row(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Padding(
              padding: const EdgeInsets.all(8.0),
              child: ElevatedButton(
                  onPressed: () async => {
                        await ContaApi.deleteConta(
                            _data["agencia"], _data["numConta"], _token),
                        _atualizarHome(),
                        Navigator.pop(context)
                      },
                  child: Text("sim")),
            ),
            Padding(
              padding: const EdgeInsets.all(8.0),
              child: ElevatedButton(
                  onPressed: () => _alteraOptions(-1), child: Text("Não")),
            ),
          ],
        )
      ],
    );
  }

  _transferir(BuildContext context) {
    final _ctrlAgencia = TextEditingController();
    final _ctrlNumConta = TextEditingController();
    final _ctrlValor = TextEditingController();
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.center,
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Text(
            "Transferencia",
            style: TextStyle(color: Colors.white, fontSize: 30),
          ),
          _textFormField("Agencia", "agencia", controller: _ctrlAgencia),
          _textFormField("Conta", "conta", controller: _ctrlNumConta),
          _textFormField("Valor", "valor", controller: _ctrlValor),
          Padding(
            padding: const EdgeInsets.all(16.0),
            child: ElevatedButton(
              onPressed: () async => {
                await ContaApi.transferirConta(
                    _token,
                    _data["agencia"],
                    _data["numConta"],
                    _ctrlAgencia.text,
                    _ctrlNumConta.text,
                    double.parse(_ctrlValor.text)),
                _atualizarHome(),
                Navigator.pop(context)
              },
              child: Text(
                "Transferir",
                style: TextStyle(color: ColorsLayout.primaryColor()),
              ),
              style: ButtonStyle(
                backgroundColor: MaterialStateProperty.all(Colors.white),
              ),
            ),
          ),
        ],
      ),
    );
  }

  _sacar(BuildContext context) {
    final _ctrlValor = TextEditingController();
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.center,
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Text(
            "Sacar",
            style: TextStyle(color: Colors.white, fontSize: 30),
          ),
          _textFormField("Valor", "valor", controller: _ctrlValor),
          Padding(
            padding: const EdgeInsets.all(16.0),
            child: ElevatedButton(
              onPressed: () async => {
                await ContaApi.sacarConta(_token, _data["agencia"],
                    _data["numConta"], double.parse(_ctrlValor.text)),
                _atualizarHome(),
                Navigator.pop(context)
              },
              child: Text(
                "Sacar",
                style: TextStyle(color: ColorsLayout.primaryColor()),
              ),
              style: ButtonStyle(
                backgroundColor: MaterialStateProperty.all(Colors.white),
              ),
            ),
          ),
        ],
      ),
    );
  }

  _depositar(BuildContext context) {
    final _ctrlValor = TextEditingController();
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.center,
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Text(
            "Depositar",
            style: TextStyle(color: Colors.white, fontSize: 30),
          ),
          _textFormField("Valor", "valor", controller: _ctrlValor),
          Padding(
            padding: const EdgeInsets.all(16.0),
            child: ElevatedButton(
              onPressed: () async => {
                await ContaApi.depositarConta(_data["agencia"],
                    _data["numConta"], double.parse(_ctrlValor.text)),
                _atualizarHome(),
                Navigator.pop(context)
              },
              child: Text(
                "Depositar",
                style: TextStyle(color: ColorsLayout.primaryColor()),
              ),
              style: ButtonStyle(
                backgroundColor: MaterialStateProperty.all(Colors.white),
              ),
            ),
          ),
        ],
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
      style: new TextStyle(color: Colors.white, decorationColor: Colors.white),
      decoration: InputDecoration(
        labelText: label,
        hintText: hint,
        labelStyle: TextStyle(color: Colors.white),
        hintStyle: TextStyle(color: Colors.white),
      ),
    );
  }
}
