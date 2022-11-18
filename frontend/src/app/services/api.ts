import axios from "axios";

const api = axios.create({
  baseURL: "https://localhost:7252"
});

export default api;
