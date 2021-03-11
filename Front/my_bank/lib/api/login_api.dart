import 'dart:convert';

import 'package:http/http.dart' as http;

class LoginApi {
  static Future<bool> login(cpf, senha) async {
    var url = Uri.https('localhost:44337', '/api/Login');

    var header = {"content-type": "application/json"};

    Map params = {"cpf": cpf, "senha": senha};
    var _body = jsonEncode(params);

    var response = await http.post(
      url,
      headers: header,
      body: _body,
    );

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
