import axios from "axios";
import { defaultURL } from "./apiSettings";


const URL = `${defaultURL}/Subordination`;

export default class Subordination {
  static async getRegions() {
    const response = await axios.get(`${URL}/GetRegions/`);
    return response;
  }

  static async getRegion(regionId) {
    const response = await axios.get(`${URL}/GetRegion/${regionId}`);
    return response;
  }

  static async getWorkshop(workshopId) {
    const response = await axios.get(`${URL}/GetWorkshop/${workshopId}`);
    return response;
  }

  static async getBrigade(brigadeId) {
    const response = await axios.get(`${URL}/GetBrigade/${brigadeId}`);
    return response;
  }

  static async getSubordinationCount(params) {
    const response = await axios.post(`${URL}/GetSubordinationCount`, params);
    return response;
  }
}