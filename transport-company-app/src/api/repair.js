import axios from "axios";
import { defaultURL } from "./apiSettings";

const URL = `${defaultURL}/Repair`;

export default class Repair {
  static async getRepairInformationByCategoryId(params) {
    const response = await axios.post(`${URL}/GetRepairInformationByCategoryId/`, params);
    return response;
  }

  static async getRepairInformationByBrandId(params) {
    const response = await axios.post(`${URL}/GetRepairInformationByBrandId/`, params);
    return response;
  }

  static async getRepairInformationByTransportId(params) {
    const response = await axios.post(`${URL}/GetRepairInformationByTransportId/`, params);
    return response;
  }

  static async getDetailsByCategoryId(params) {
    const response = await axios.post(`${URL}/GetDetailsByCategoryId/`, params);
    return response;
  }

  static async getDetailsByBrandId(params) {
    const response = await axios.post(`${URL}/GetDetailsByBrandId/`, params);
    return response;
  }

  static async getDetailsByTransportId(params) {
    const response = await axios.post(`${URL}/GetDetailsByTransportId/`, params);
    return response;
  }

  static async getRepairByPersonId(params) {
    const response = await axios.post(`${URL}/GetRepairByPersonId/`, params);
    return response;
  }

  static async getRepairByPersonIdAndTransportId(params) {
    const response = await axios.post(`${URL}/GetRepairByPersonIdAndTransportId/`, params);
    return response;
  }

  static async getDetails() {
    const response = await axios.get(`${URL}/GetDetails/`);
    return response;
  }
}
