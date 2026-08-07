import api from "../api/api";

export function getAllDepartments() {
  return api.get("/Department/GetAll");
}
export async function addDepartment(data) {
  const response = await api.post("/Department/Create", data);
  return response.data;
}
