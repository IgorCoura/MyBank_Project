import 'package:flutter/material.dart';
import 'package:my_bank/layout/colors_layout.dart';

class OptionsContaWidget extends StatelessWidget {
  final int options;
  OptionsContaWidget(this.options);
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
                        child: options == 4 ? _deletar() : Container()),
                  ),
                ],
              ),
            ),
          )
        : Container();
  }

  _deletar() {
    return Column(
      children: [
        Text("Deseja excluir essa conta?"),
        Row(
          children: [
            ElevatedButton(onPressed: () => {}, child: Text("sim")),
            ElevatedButton(onPressed: () => {}, child: Text("Não")),
          ],
        )
      ],
    );
  }

  _transferir() {}
  _sacar() {}
  _depositar() {}
}
