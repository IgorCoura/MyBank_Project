import 'package:flutter/material.dart';
import 'package:my_bank/api/home_api.dart';
import 'package:my_bank/components/conta_widget.dart';
import 'package:my_bank/layout/colors_layout.dart';

class HomePage extends StatefulWidget {
  final Map<String, dynamic> data;
  HomePage(this.data);
  @override
  _HomePageState createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  @override
  Widget build(BuildContext context) {
    var primeiroNome = widget.data["nameCliente"].split(" ")[0];
    return Scaffold(
      appBar: AppBar(
        title: Text("Olá, $primeiroNome"),
        backgroundColor: ColorsLayout.primaryColor(),
      ),
      backgroundColor: ColorsLayout.backgroundColor(),
      body: FutureBuilder(
        future: HomeApi.recoverContas(widget.data["token"]),
        builder: (context, snapshot) {
          if (snapshot.hasData) {
            return ListView.builder(
                itemCount:
                    snapshot.data.length > 0 ? snapshot.data.length + 1 : 2,
                itemBuilder: (context, index) {
                  if (snapshot.data.length < 1 && index < 1) {
                    return Container(
                      alignment: Alignment.center,
                      padding: const EdgeInsets.all(20),
                      child: Text(
                        "Você ainda não tem nenhuma conta.",
                        style: TextStyle(color: Colors.white, fontSize: 15),
                      ),
                    );
                  } else if (index < snapshot.data.length) {
                    return ContaWidget(
                        snapshot.data[index], widget.data["token"]);
                  } else {
                    return _buttonWidget();
                  }
                });
          } else {
            return Center(
              child: SizedBox(
                child: CircularProgressIndicator(),
                width: 60,
                height: 60,
              ),
            );
          }
        },
      ),
    );
  }

  _buttonWidget() => Container(
        alignment: AlignmentDirectional.topCenter,
        margin: const EdgeInsets.fromLTRB(50, 0, 50, 20),
        child: ElevatedButton(
          style: ButtonStyle(
            shape: MaterialStateProperty.all<RoundedRectangleBorder>(
                RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(18.0),
                    side: BorderSide(color: ColorsLayout.primaryColor()))),
            backgroundColor: MaterialStateProperty.all<Color>(Colors.white),
          ),
          onPressed: () =>
              {HomeApi.createConta(widget.data["token"]), setState(() {})},
          child: Text(
            "Criar uma nova conta",
            style: TextStyle(color: ColorsLayout.primaryColor()),
          ),
        ),
      );
}
