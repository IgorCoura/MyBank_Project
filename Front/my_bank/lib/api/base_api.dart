import 'dart:convert';
import 'package:http/http.dart' as http;

class BaseApi {
  static final String _host = "localhost:44337";
  static final Map<String, String> _header = {
    "content-type": "application/json",
  };

  static Future<http.Response> apiPost(Map params, String path,
      {String token}) async {
    var url = Uri.https(_host, path);
    var _body = jsonEncode(params);
    _header["Authorization"] = "bearer $token";
    http.Response response;
    try {
      response = await http.post(url, headers: _header, body: _body);
      return response;
    } catch (e) {
      print(e);
      return null;
    }
  }

  static Future<http.Response> apiGet(String path,
      {Map query, String token}) async {
    _header["Authorization"] = "bearer $token";
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

  static Future<http.Response> apiDelete(String path, Map params,
      {String token}) async {
    _header["Authorization"] = "bearer $token";
    var url = Uri.https(_host, path);
    var _body = jsonEncode(params);
    http.Response response;
    try {
      response = await http.delete(url, headers: _header, body: _body);
      return response;
    } catch (e) {
      print(e);
      return null;
    }
  }

  static Future<http.Response> apiPatch(String path, Map params,
      {String token}) async {
    _header["Authorization"] = "bearer $token";
    var url = Uri.https(_host, path);
    var _body = jsonEncode(params);
    http.Response response;
    try {
      response = await http.patch(url, headers: _header, body: _body);
      return response;
    } catch (e) {
      print(e);
      return null;
    }
  }
}
