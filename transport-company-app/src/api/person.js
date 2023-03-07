import axios from "axios";
import { defaultURL } from "./apiSettings";


const URL = `${defaultURL}/Person`;

export default class Person {
  static async getPersonById(id) {
    const response = await axios.get(`${URL}/GetPersons/${id}`);
    return response;
  }

  static async getPersons(params) {
    const response = await axios.post(`${URL}/GetPersons/`, params);
    return response;
  }

  static async getPersonCount(params) {
    const response = await axios.post(`${URL}/GetPersonCount/`, params);
    return response;
  }

  static async getPersonPositions() {
    const response = await axios.get(`${URL}/GetPersonPositions`);
    return response;
  }
}
