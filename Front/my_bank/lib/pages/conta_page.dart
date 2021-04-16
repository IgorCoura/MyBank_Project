import 'dart:developer';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/painting.dart';
import 'package:my_bank/components/options_conta_widget.dart';
import 'package:my_bank/layout/colors_layout.dart';

class ContaPage extends StatefulWidget {
  final Map data;
  final String token;

  ContaPage(this.data, this.token);

  @override
  _ContaPageState createState() => _ContaPageState();
}

class _ContaPageState extends State<ContaPage> {
  int _options = 0;

  _alteraOption(int number) {
    _options = number;
    setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    var widthScreen = MediaQuery.of(context).size.width;
    var heigthScreen = MediaQuery.of(context).size.height;

    _button(String text, int numButton, int number) {
      return GestureDetector(
        onTap: () => {_alteraOption(number)},
        child: Container(
          margin: const EdgeInsets.all(10),
          padding: const EdgeInsets.all(5),
          height: (widthScreen / numButton) - 20,
          width: (widthScreen / numButton) - 20,
          color: ColorsLayout.primaryColor(),
          child: Center(
              child: Text(
            text,
            style: TextStyle(color: Colors.white),
            textAlign: TextAlign.center,
          )),
        ),
      );
    }

    return Scaffold(
      appBar: AppBar(
        title: Text(
            "Agencia: ${widget.data["agencia"]}   Conta: ${widget.data["numConta"]}"),
        backgroundColor: ColorsLayout.primaryColor(),
      ),
      backgroundColor: ColorsLayout.backgroundColor(),
      body: Stack(
        children: [
          Column(
            children: [
              Expanded(
                child: Container(
                  margin: const EdgeInsets.all(10),
                  color: Colors.white,
                  width: widthScreen,
                  padding: const EdgeInsets.all(8),
                  child: Column(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Text(
                        "Saldo disponível: ",
                        style: TextStyle(
                          color: ColorsLayout.primaryColor(),
                          fontSize: 20,
                        ),
                      ),
                      Text(
                        "R\$ 1.000.500,22",
                        style: TextStyle(
                          color: ColorsLayout.primaryColor(),
                          fontSize: 45,
                        ),
                      ),
                    ],
                    crossAxisAlignment: CrossAxisAlignment.start,
                  ),
                ),
              ),
              Container(
                height: heigthScreen / 5,
                color: ColorsLayout.backgroundColor(),
                child: Row(
                  children: [
                    _button("Depositar", 4, 1),
                    _button("Sacar", 4, 2),
                    _button("Transferir", 4, 3),
                    _button("Deletar conta", 4, 4),
                  ],
                ),
              )
            ],
          ),
          OptionsContaWidget(_options)
        ],
      ),
    );
  }
}
