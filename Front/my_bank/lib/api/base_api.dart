import 'dart:convert';
import 'package:http/http.dart' as http;

class BaseApi {
  static final String _host = "localhost:44337";
  static final Map<String, String> _header = {
    "content-type": "application/json"
  };

  static Future<http.Response> apiPost(Map params, String path) async {
    var url = Uri.https(_host, path);

    var _body = jsonEncode(params);
    http.Response response;
    try {
      response = await http.post(url, headers: _header, body: _body);
      return response;
    } catch (e) {
      print(e);
      return null;
    }
  }

  static Future<http.Response> apiGet(String path, {Map query}) async {
    var url = Uri.https(_host, path, query);
    http.Response response;
    try {
      response = await http.get(url, headers: _header);
      return response;
    } catch (e) {
      print(e);
      return null;
    }
  }
}
