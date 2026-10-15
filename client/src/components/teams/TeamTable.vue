
<script setup>
import Table from "../../components/common/Table.vue";
import { Eye, SquarePen, Trash2 } from "@lucide/vue";

const columns = [
  {
    key: "name",
    label: "Takım Adı",
  },
  {
    key: "description",
    label: "Açıklaması",
  },
  {
    key: "isActive",
    label: "Durumu",
  },
  {
    key: "createdAt",
    label: "Oluşturulma Tarihi",
  },
];

defineProps({
  teams: {
    type: Array,
    required: true,
  },
});
</script>

<template>
  <section class="w-full min-w-0">
    <!-- Başlık ve yeni takım butonu -->
    <div
      class="mb-4 flex flex-col gap-3 sm:flex-row sm:items-center sm:justify-between"
    >
      <h2 class="text-xl font-bold text-white sm:text-2xl">
        Takımlar
      </h2>

      <RouterLink
        to="/teams/add"
        class="inline-flex min-h-10 w-full items-center justify-center gap-2 rounded-lg bg-white px-5 py-2 text-sm font-medium text-slate-950 transition hover:bg-gray-200 sm:w-auto sm:px-6"
      >
        Yeni Takım
      </RouterLink>
    </div>

    <Table :columns="columns" :items="teams">
      <!-- Durum sütunu -->
      <template #cell-isActive="{ item }">
        <span
          v-if="item.isActive"
          class="inline-flex whitespace-nowrap rounded-xl border border-green-900 bg-green-600/10 px-3 py-2 text-sm text-green-400"
        >
          Aktif
        </span>

        <span
          v-else
          class="inline-flex whitespace-nowrap rounded-xl border border-yellow-500/50 bg-yellow-600/10 px-3 py-2 text-sm text-yellow-400"
        >
          Pasif
        </span>
      </template>

      <!-- İşlem butonları -->
      <template #actions="{ item }">
        <div class="flex justify-end gap-2">
          <button
            type="button"
            aria-label="Takımı görüntüle"
            @click="editTeam(item)"
            class="flex h-9 w-9 shrink-0 items-center justify-center rounded-lg bg-gray-600/50 transition hover:bg-gray-600"
          >
            <Eye :size="20" class="text-gray-300" />
          </button>

          <button
            type="button"
            aria-label="Takımı düzenle"
            @click="editTeam(item)"
            class="flex h-9 w-9 shrink-0 items-center justify-center rounded-lg bg-indigo-400/60 transition hover:bg-indigo-400"
          >
            <SquarePen :size="20" class="text-blue-950" />
          </button>

          <button
            type="button"
            aria-label="Takımı sil"
            @click="deleteTeam(item.id)"
            class="flex h-9 w-9 shrink-0 items-center justify-center rounded-lg bg-red-500/30 transition hover:bg-red-500/50"
          >
            <Trash2 :size="20" class="text-rose-400" />
          </button>
        </div>
      </template>
    </Table>
  </section>
</template>
