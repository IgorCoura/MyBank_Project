import 'package:flutter/material.dart';

class ContaWidget extends StatelessWidget {
  final Map data;
  ContaWidget(this.data);
  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: () => {},
      child: Container(
        padding: const EdgeInsets.all(16.0),
        margin: const EdgeInsets.all(20),
        decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(5),
          color: Colors.white,
        ),
        child: Column(
          children: [
            Container(
              alignment: Alignment.topLeft,
              child: Text(
                  "Agencia: ${data["agencia"]}  Conta: ${data["numConta"]}"),
            ),
            Container(
              color: Colors.white60,
              margin: const EdgeInsets.fromLTRB(0, 15, 0, 0),
              alignment: Alignment.bottomLeft,
              child: Text(
                "Saldo: ${data["saldo"]}",
                style: TextStyle(fontSize: 30),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
