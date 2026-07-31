import api from "../api/api";

export function getStatisctics()
{
    return api.get("/Dashboard/Statistics");
}