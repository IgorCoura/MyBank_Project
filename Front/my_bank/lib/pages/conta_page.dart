import 'dart:developer';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/painting.dart';
import 'package:my_bank/layout/colors_layout.dart';

class ContaPage extends StatelessWidget {
  final Map data;
  final String token;
  ContaPage(this.data, this.token);
  @override
  Widget build(BuildContext context) {
    var widthScreen = MediaQuery.of(context).size.width;

    _button(String text, int numButton, Function func) {
      return GestureDetector(
        onTap: () => func,
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
        title: Text("Agencia: ${data["agencia"]}   Conta: ${data["numConta"]}"),
        backgroundColor: ColorsLayout.primaryColor(),
      ),
      backgroundColor: ColorsLayout.backgroundColor(),
      body: Column(
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
            color: ColorsLayout.backgroundColor(),
            child: Row(
              children: [
                _button("Depositar", 4, null),
                _button("Sacar", 4, null),
                _button("Transferir", 4, null),
                _button("Deletar conta", 4, null),
              ],
            ),
          )
        ],
      ),
    );
  }
}
