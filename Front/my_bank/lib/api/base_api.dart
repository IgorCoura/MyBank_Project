import 'dart:convert';
import 'package:http/http.dart' as http;

class BaseApi {
  static final String _host = "localhost:44337";

  static Future<http.Response> apiPost(Map params, String path) async {
    var url = Uri.https(_host, path);
    var header = {"content-type": "application/json"};
    var _body = jsonEncode(params);
    http.Response response;
    try {
      response = await http.post(url, headers: header, body: _body);
      return response;
    } catch (e) {
      print(e);
      return null;
    }
  }
}
