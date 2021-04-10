import 'dart:convert';

import 'package:http/http.dart' as http;
import 'package:my_bank/api/base_api.dart';
import 'package:my_bank/api/home_api.dart';

class LoginApi {
  static Future<Map<String, dynamic>> login(cpf, senha) async {
    Map params = {"cpf": "67728949012", "senha": "123789"};

    http.Response response = await BaseApi.apiPost(params, "/api/Login");

    if (response == null) return null;

    Map<String, dynamic> jsonResponse = jsonDecode(response.body);

    if (response.statusCode == 200) {
      print('Request status: ${response.statusCode}.');
      print('Token: ${jsonResponse["token"]}');
      return jsonResponse;
    } else {
      print('Request status: ${response.statusCode}.');
      print('Token: $jsonResponse.');
      return null;
    }
  }
}
