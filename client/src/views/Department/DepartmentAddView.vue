<script setup>
import { ref, onMounted } from "vue";
import DepartmentCreate from "../../components/departments/DepartmentCreate.vue";
import { addDepartment } from "@/services/departmentService";

const departments = ref([]);

async function saveDepartment(departments) {
    await addDepartment(departments);
}
</script>
<template>
    <div class="page">
        <DepartmentCreate @save="saveDepartment" />
    </div>
</template>