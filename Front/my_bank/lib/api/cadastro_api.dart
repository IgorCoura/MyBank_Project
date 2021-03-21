import 'dart:convert';

import 'package:http/http.dart';
import 'package:my_bank/api/base_api.dart';

class CadastroApi {
  static Future<bool> cadastro(
      var nome, var cpf, var dataNascimento, var senha) async {
    Map params = {
      "nome": nome,
      "cpf": cpf,
      "dataNascimento": dataNascimento,
      "senha": senha,
    };
    Response reponse = await BaseApi.apiPost(params, "/api/Cliente");

    if (reponse.statusCode < 200 ||
        reponse.statusCode >= 300 ||
        reponse == null) {
      print(jsonDecode(reponse.body));
      return false;
    } else {
      return true;
    }
  }
}
