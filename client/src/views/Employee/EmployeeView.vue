<script setup>
import { ref, onMounted, computed } from "vue";
import { getEmployees, getEmployeeById } from "../../services/employeeService";
import EmployeeTable from "../../components/employees/EmployeeTable.vue"

const search = ref("");

const page = ref(1);
const pageSize = 3;

const allemployees = ref([]);
const employees = ref([]);

const showModal = ref(false);
const selectedEmployee = ref(null);

async function loadEmployees() {

    const response = await getEmployees(page.value, pageSize);

    employees.value = response.data;
}

onMounted(async () => {
    await loadEmployees();
});

const filteredEmployees = computed(() => {

    if (!search.value.trim()) {
        return employees.value;
    }

    return employees.value.filter(employee =>
        `${employee.firstName}`
            .toLowerCase()
            .includes(search.value.toLowerCase()) // burayı araştır
    );

});

async function openEditModal(id) {
    const response = await getEmployeeById(id);

    selectedEmployee.value = response.data;
    showModal.value = true;
}

function closeModal() {
    showModal.value = false;
    selectedEmployee.value = null;
}

async function nextPage() {
    page.value++;

    await loadEmployees();
}
async function previousPage() {
    if (page.value > 1) {
        page.value--;

        await loadEmployees();
    }
}

</script>

<template>

    <div class="page">
        <EmployeeTable v-model="search" :employees="filteredEmployees" @edit="openEditModal" @nextPage="nextPage"
            @previousPage="previousPage" />
    </div>

</template>

<style scoped>
.page {

    padding: 35px;
    min-height: 100vh;
}
</style>