import axios from "axios";
import { defaultURL } from "./apiSettings";

const URL = `${defaultURL}/Transport`;

export default class Transport {
  static async getTransports(params) {
    const response = await axios.post(`${URL}/GetTransports/`, params);
    return response;
  }

  static async getTransportById(id) {
    const response = await axios.get(`${URL}/GetTransports/${id}`);
    return response;
  }

  static async getTransportCount(params) {
    const response = await axios.post(`${URL}/GetTransportCount/`, params);
    return response;
  }

  static async getTransportCategories() {
    const response = await axios.get(`${URL}/GetTransportCategories/`);
    return response;
  }

  static async getTransportCountries() {
    const response = await axios.get(`${URL}/GetTransportCountries/`);
    return response;
  }

  static async getGarageFacilityCountByCategoryId(categoryId) {
    return await axios.get(
      `${URL}/GetGarageFacilityCountByCategoryId/${categoryId}`
    );
  }

  static async getCargoTransportations(params) {
    const response = await axios.post(
      `${URL}/GetCargoTransportations/`,
      params
    );
    return response;
  }
}
