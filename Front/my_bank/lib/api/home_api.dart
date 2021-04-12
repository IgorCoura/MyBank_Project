import 'dart:convert';
import 'package:http/http.dart';
import 'base_api.dart';

class HomeApi {
  static Future<List<dynamic>> recoverContas(String params) async {
    var path = "/api/Cliente/RecoverByToken";
    Map<String, dynamic> query = {
      "token": params,
    };
    Response reponse = await BaseApi.apiGet(path, query: query);
    Map<String, dynamic> json = jsonDecode(reponse.body);
    return json["contaModel"];
  }

  static void createConta(String token) async {
    var path = "/api/Conta/Register";
    Map<String, String> params = {
      "token": token,
    };
    await BaseApi.apiPost(params, path);
  }
}
