<script setup>
import { ref } from "vue";
import { Plus } from "@lucide/vue";
// import DepartmentSearch from "./DepartmentSearch.vue";

defineProps({
    departments: Array
});

// const search = defineModel();
const emit = defineEmits([
    "edit"
]);
</script>

<template>
    <div class="bg-[#18181C] p-6 rounded-xl shadow-[0_10px_30px_rgba(0,0,0,0.08)]">

        <div class="flex justify-between items-center mb-4">

            <h2 class="text-2xl font-bold text-white">Departmanlar</h2>

            <RouterLink to="departments/add" class="flex items-center gap-2 bg-white p-2 px-6 rounded-lg text-slate-950 hover:bg-slate-700 hover:duration-300">
                <Plus :size="20" />
                <span>Yeni Departman</span>
            </RouterLink>

        </div>

        <table class="w-full border-separate border-spacing-0 overflow-hidden rounded-xl">

            <thead class="bg-[#26262A] text-white">
                <tr>
                    <th class="p-4 text-left">Id</th>
                    <th class="p-4 text-left">Departman Adı</th>
                    <th class="p-4 text-left">Açıklaması</th>
                    <th class="p-4 text-left">Oluşturulma Tarihi</th>
                </tr>
            </thead>

            <tbody>
                <tr v-for="department in departments" :key="department.id"
                    class="text-lg text-white transition-all duration-200">
                    <td class="p-4 border-b border-gray-200">{{ department.id }}</td>
                    <td class="p-4 border-b border-gray-200">{{ department.name }}</td>
                    <td class="p-4 border-b border-gray-200">{{ department.description }}</td>
                    <td class="p-4 border-b border-gray-200">{{ department.createdAt }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>