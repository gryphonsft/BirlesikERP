import api from "../api/api";

// Kullanıcıları basitçe getir
export function getEmployees(page, pageSize) {
  return api.get("/Employee/Get",{
    params:{
      page,
      pageSize
    }
  });
}
// Kullanıcı araması
export function searchEmployee(search) {
  return api.get("/Employee/Search", {
    params: {
      value: search,
    },
  });
}
// Id'ye göre kullanıcı getir.
export function getEmployeeById(id) {
    return api.get("/Employee/GetById", {
        params: {
            Id: id
        }
    });
}
