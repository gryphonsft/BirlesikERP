<script setup>
import { ref, onMounted } from "vue";
import { getAllDepartments } from "../../services/departmentService";
import  DepartmentTable  from "../../components/departments/DepartmentTable.vue";

const departments = ref([]);

async function loadDepartments() {

    const response = await getAllDepartments();
    departments.value = response.data;
}
onMounted(async () => {
    await loadDepartments();
});
</script>
<template>

    <div class="page">
        <DepartmentTable :departments="departments" />
    </div>
</template>
<style scoped>
.page {

    padding: 35px;
    min-height: 100vh;
}
</style>