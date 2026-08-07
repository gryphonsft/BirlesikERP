<script setup>
import { ref, onMounted } from "vue";
import TeamAdd from "../../components/teams/TeamAdd.vue";
import { addTeam } from "../../services/teamService";
import { getAllDepartments } from "../../services/departmentService";

const teams = ref([]);
const departments = ref([]);

async function loadDepartments() {
    try {
        const response = await getAllDepartments();
        departments.value = response.data;
    } catch (err) {
        console.error(err);
    }
}

async function saveTeams(teams) {
    await addTeam(teams);
}
onMounted(async () => {
    await loadDepartments();
});
</script>
<template>
    <div class="page">
        <TeamAdd :departments="departments" @save="saveTeams" />
    </div>
</template>