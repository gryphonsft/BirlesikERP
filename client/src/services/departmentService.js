import api from "../api/api";

export function getAllDepartments()
{
    return api.get("/Department/GetAll")
}