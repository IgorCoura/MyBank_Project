import 'dart:convert';

import 'package:http/http.dart' as http;
import 'package:my_bank/api/base_api.dart';

class LoginApi {
  static Future<bool> login(cpf, senha) async {
    Map params = {"cpf": cpf, "senha": senha};
    http.Response response = await BaseApi.apiPost(params, "/api/Login");
    if (response == null) return false;
    var jsonResponse = jsonDecode(response.body);
    if (response.statusCode == 200) {
      print('Request status: ${response.statusCode}.');
      print('Token: $jsonResponse.');
      return true;
    } else {
      print('Request status: ${response.statusCode}.');
      print('Token: $jsonResponse.');
      return false;
    }
  }
}
