<script setup>
import { ref } from "vue";
import EmployeeSearch from './EmployeeSearch.vue';

defineProps({
  employees: Array,
  count: Number
});

const search = defineModel();
const emit = defineEmits([
  "edit",
  "nextPage",
  "previousPage"
]);
</script>

<template>
  <div class="bg-[#18181C] p-6 rounded-xl shadow-[0_10px_30px_rgba(0,0,0,0.08)]">

    <div class="flex justify-between items-center mb-4">
      <div class="flex items-center gap-5">
        <h2 class="text-2xl font-bold text-white">Çalışanlar</h2>

        <EmployeeSearch v-model="search" />
      </div>
    </div>

    <table class="w-full border-separate border-spacing-0 overflow-hidden rounded-xl">

      <thead class="bg-[#26262A] text-white">
        <tr>
          <th class="p-4 text-left">Id</th>
          <th class="p-4 text-left">Ad</th>
          <th class="p-4 text-left">Soyad</th>
          <th class="p-4 text-left"></th>
        </tr>
      </thead>

      <tbody>
        <tr
          v-for="employee in employees"
          :key="employee.id"
          class="text-lg text-white transition-all duration-200"
        >
          <td class="p-4 border-b border-gray-200">{{ employee.id }}</td>
          <td class="p-4 border-b border-gray-200">{{ employee.firstName }}</td>
          <td class="p-4 border-b border-gray-200">{{ employee.lastName }}</td>
          <td class="p-4 border-b border-gray-200">
            <button
              class="bg-[#26262A] text-white px-3 py-2 rounded hover:bg-[#313136] transition-colors"
              @click="emit('edit', employee.id)"
            >
              Detaylı
            </button>
          </td>
        </tr>
      </tbody>

    </table>

    <div class="flex justify-end gap-4 mt-4">
      <button
        class="bg-[#26262A] text-white px-4 py-2 rounded hover:bg-[#313136] transition-colors"
        @click="emit('previousPage')"
      >
        Önceki Sayfa
      </button>

      <button
        class="bg-[#26262A] text-white px-4 py-2 rounded hover:bg-[#313136] transition-colors"
        @click="emit('nextPage')"
      >
        Sonraki Sayfa
      </button>
    </div>

  </div>
</template>