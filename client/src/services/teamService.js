import api from "../api/api";

export async function getTeams() {
  return await api.get("Team/GetAll");
}
export async function addTeam(data) {
    const response = await api.post("Team/Create",data);
    return response.data;
}
