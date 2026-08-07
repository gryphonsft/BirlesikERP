<script setup>
import { ref } from "vue";
import { Plus } from "@lucide/vue";
// import DepartmentSearch from "./DepartmentSearch.vue";

defineProps({
    teams: Array
});

// const search = defineModel();
const emit = defineEmits([
    "edit"
]);
</script>

<template>
    <div class="bg-[#18181C] p-6 rounded-xl shadow-[0_10px_30px_rgba(0,0,0,0.08)]">

        <div class="flex justify-between items-center mb-4">

            <h2 class="text-2xl font-bold text-white">Takımlar</h2>

            <RouterLink to="teams/add"
                class="flex items-center gap-2 bg-white p-2 px-6 rounded-lg text-slate-950 hover:bg-slate-700 hover:duration-300">
                <Plus :size="20" />
                <span>Yeni Takım</span>
            </RouterLink>

        </div>

        <table class="w-full border-separate border-spacing-0 overflow-hidden rounded-xl">

            <thead class="bg-[#26262A] text-white">
                <tr>
                    <th class="p-4 text-left">Id</th>
                    <th class="p-4 text-left">Takım Adı</th>
                    <th class="p-4 text-left">Açıklaması</th>
                    <th class="p-4 text-left">Durumu</th>
                    <th class="p-4 text-left">Oluşturulma Tarihi</th>
                </tr>
            </thead>

            <tbody>
                <tr v-for="team in teams" :key="team.id" class="text-lg text-white transition-all duration-200">
                    <td class="p-4 border-b border-gray-200">{{ team.id }}</td>
                    <td class="p-4 border-b border-gray-200">{{ team.name }}</td>
                    <td class="p-4 border-b border-gray-200">{{ team.description }}</td>
                    <td class="p-4 border-b border-gray-200">{{ team.ısActive }}</td>
                    <td class="p-4 border-b border-gray-200">{{ team.createdAt }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>