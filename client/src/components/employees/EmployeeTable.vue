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
  <div class="card bg-white">
    <div class="card-header mb-4">
      <div class="left">
        <h2 class="text-2xl font-bold">Çalışanlar</h2>

        <EmployeeSearch v-model="search" />

      </div>
      <span class="count font-bold">
        {{ count }} Kayıt
      </span>
    </div>

    <table class="table">

      <thead class="text-dark">
        <tr>
          <th>Id</th>
          <th>Ad</th>
          <th>Soyad</th>
          <th></th>
        </tr>
      </thead>

      <tbody>
        <tr v-for="employee in employees" :key="employee.id" class="text-lg">
          <td>{{ employee.id }}</td>
          <td>{{ employee.firstName }}</td>
          <td>{{ employee.lastName }}</td>
          <td>
            <button class="bg-blue-600 text-white px-3 py-1 rounded hover:bg-blue-700"
              @click="emit('edit', employee.id)">
              Detaylı
            </button>
          </td>
        </tr>
      </tbody>
    </table>
    <div class="flex gap-4 justify-end">
    <button class="bg-blue-600 rounded-2xl p-2  text-white mt-2" @click="emit('previousPage')">
      Önceki Sayfa
    </button>
    <button class="bg-blue-600 rounded-2xl p-2 text-white mt-2" @click="emit('nextPage')">
      Sonraki Sayfa
    </button>
  </div>
  </div>

</template>

<style scoped>
.card {
  border-radius: 15px;
  padding: 25px;
  box-shadow: 0 10px 30px rgba(0, 0, 0, .08);

}

.card-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.card-header h2 {
  margin: 0;
  color: #1e293b;
}

.count {

  background: #2563eb;
  color: white;
  padding: 8px 15px;
  border-radius: 20px;
  font-size: 14px;

}

.table {
  width: 100%;
  border-collapse: separate;
  border-spacing: 0;
  border-radius: 12px;
  overflow: hidden;
}



.table th {

  padding: 16px;
  text-align: left;

}

.table td {

  padding: 15px;
  border-bottom: 1px solid #eee;

}

.table tbody tr {

  transition: .25s;

}

.table tbody tr:hover {

  background: #f8fafc;

}

.person {

  display: flex;
  align-items: center;
  gap: 15px;

}

.avatar {

  width: 45px;
  height: 45px;
  border-radius: 50%;
  background: #2563eb;
  color: white;
  display: flex;
  justify-content: center;
  align-items: center;
  font-weight: bold;
  font-size: 18px;

}

.name {

  font-weight: 600;

}

.birth {

  color: gray;
  font-size: 13px;

}

.badge {

  padding: 6px 15px;
  border-radius: 25px;
  font-size: 13px;
  font-weight: bold;

}

.active {

  background: #dcfce7;
  color: #166534;

}

.passive {

  background: #fee2e2;
  color: #991b1b;

}

.left {
  display: flex;
  align-items: center;
  gap: 20px;
}
</style>