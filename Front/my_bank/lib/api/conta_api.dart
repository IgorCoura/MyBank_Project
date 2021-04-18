import 'package:http/http.dart';
import 'package:my_bank/api/base_api.dart';

class ContaApi {
  static Future<bool> deleteConta(
      String agencia, String numConta, String token) async {
    Map params = {
      "agencia": agencia,
      "numConta": numConta,
      "token": token,
    };
    Response reponse =
        await BaseApi.apiDelete("/api/Conta/Deletar", params, token: token);

    if (reponse.statusCode >= 200 || reponse.statusCode < 300) {
      return true;
    } else {
      return false;
    }
  }

  static Future<bool> transferirConta(
    String token,
    String agenciaOrigem,
    String numContaOrigim,
    String agenciaDestino,
    String numContaDestino,
    double valor,
  ) async {
    Map params = {
      "token": token,
      "agenciaOrigem": agenciaOrigem,
      "numContaOrigem": numContaOrigim,
      "agenciaDestino": agenciaDestino,
      "numContaDestino": numContaDestino,
      "valor": valor,
    };
    Response reponse =
        await BaseApi.apiPatch("/api/Conta/Transferir", params, token: token);

    if (reponse.statusCode >= 200 || reponse.statusCode < 300) {
      return true;
    } else {
      return false;
    }
  }

  static Future<bool> sacarConta(
    String token,
    String agencia,
    String numConta,
    double valor,
  ) async {
    Map params = {
      "token": token,
      "agencia": agencia,
      "numConta": numConta,
      "valor": valor,
    };
    Response reponse =
        await BaseApi.apiPatch("/api/Conta/Sacar", params, token: token);
    if (reponse.statusCode >= 200 || reponse.statusCode < 300) {
      return true;
    } else {
      return false;
    }
  }

  static Future<bool> depositarConta(
      String agencia, String numConta, double valor, String token) async {
    Map params = {
      "token": "",
      "agencia": agencia,
      "numConta": numConta,
      "valor": valor,
    };

    Response reponse =
        await BaseApi.apiPatch("/api/Conta/Depositar", params, token: token);
    if (reponse.statusCode >= 200 || reponse.statusCode < 300) {
      return true;
    } else {
      return false;
    }
  }
}
