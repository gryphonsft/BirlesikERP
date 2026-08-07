<script setup>
import { ref, onMounted } from "vue";
import { getTeams } from '../../services/teamService.js';
import TeamTable from "../../components/teams/TeamTable.vue";

const teams = ref([]);

async function loadTeams() {
    const response = await getTeams();
    teams.value = response.data;
}

onMounted(async () => {
    await loadTeams();
});
</script>

<template>
    <div class="page">
        <TeamTable :teams="teams" />
    </div>
</template>
<style scoped>
.page {

    padding: 35px;
    min-height: 100vh;
}
</style>