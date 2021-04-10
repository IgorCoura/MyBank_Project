import 'package:flutter/material.dart';
import 'package:my_bank/api/home_api.dart';
import 'package:my_bank/components/conta_widget.dart';
import 'package:my_bank/layout/colors_layout.dart';

class HomePage extends StatelessWidget {
  final Map<String, dynamic> data;
  HomePage(this.data);

  @override
  Widget build(BuildContext context) {
    var primeiroNome = data["nameCliente"].split(" ")[0];
    return Scaffold(
      appBar: AppBar(
        title: Text("Olá, $primeiroNome"),
        backgroundColor: ColorsLayout.primaryColor(),
      ),
      backgroundColor: ColorsLayout.backgroundColor(),
      body: FutureBuilder(
        future: HomeApi.recoverContas(data["token"]),
        builder: (context, snapshot) {
          if (snapshot.connectionState == ConnectionState.none &&
              snapshot.data == null) {
            return Container();
          }
          return ListView.builder(
            itemCount: snapshot.data.length,
            itemBuilder: (context, index) {
              return ContaWidget(snapshot.data[index]);
            },
          );
        },
      ),
    );
  }
}
