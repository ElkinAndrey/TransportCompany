import axios from "axios";
import { defaultURL } from "./apiSettings";

const URL = `${defaultURL}/Transport`;

export default class Transport {
  static async getTransports(params) {
    const response = await axios.post(`${URL}/GetTransports/`, params);
    return response;
  }

  static async getTransportCount(params) {
    const response = await axios.post(`${URL}/GetTransportCount/`, params);
    return response;
  }
}
