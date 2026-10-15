
<script setup>
import {
  Users,
  Search,
  Folders,
  CircleCheck,
  ChevronDown,
  RefreshCcw
} from "@lucide/vue";

defineProps({
  columns: {
    type: Array,
    required: true
  },
  items: {
    type: Array,
    required: true
  }
});
</script>

<template>
  <div class="min-w-0 w-full">

    <!-- İstatistik kartları -->
    <div class="grid grid-cols-1 gap-4 sm:grid-cols-2 xl:grid-cols-4">

      <div
        class="flex min-h-32 items-center gap-4 rounded-xl border border-slate-700/50 p-5"
        style="background-color: #1C2532;"
      >
        <div
          class="flex h-12 w-12 shrink-0 items-center justify-center rounded-xl"
          style="background-color: #42248A;"
        >
          <Users :size="24" class="text-purple-300" />
        </div>

        <div class="min-w-0 flex-1">
          <p class="text-xs text-slate-400">Toplam Takım</p>
          <p class="mt-1 text-2xl font-bold text-white">12</p>
          <p class="mt-1 text-xs text-slate-400">Aktif takımlar</p>
        </div>
      </div>

      <div
        class="flex min-h-32 items-center gap-4 rounded-xl border border-slate-700/50 p-5"
        style="background-color: #1C2532;"
      >
        <div class="flex h-12 w-12 shrink-0 items-center justify-center rounded-xl bg-blue-400">
          <Users :size="24" class="text-blue-950" />
        </div>

        <div class="min-w-0 flex-1">
          <p class="text-xs text-slate-400">Toplam Kullanıcı</p>
          <p class="mt-1 text-2xl font-bold text-white">128</p>
          <p class="mt-1 text-xs text-slate-400">Aktif kullanıcılar</p>
        </div>

        <div class="shrink-0 self-end pb-1 text-xs font-medium text-green-400">
          ↑ 8%
        </div>
      </div>

      <div
        class="flex min-h-32 items-center gap-4 rounded-xl border border-slate-700/50 p-5"
        style="background-color: #1C2532;"
      >
        <div class="flex h-12 w-12 shrink-0 items-center justify-center rounded-xl bg-yellow-400">
          <Folders :size="24" class="text-yellow-950" />
        </div>

        <div class="min-w-0 flex-1">
          <p class="text-xs text-slate-400">Aktif Projeler</p>
          <p class="mt-1 text-2xl font-bold text-white">24</p>
          <p class="mt-1 text-xs text-slate-400">Devam eden projeler</p>
        </div>

        <div class="shrink-0 self-end pb-1 text-xs font-medium text-green-400">
          ↑ 15%
        </div>
      </div>

      <div
        class="flex min-h-32 items-center gap-4 rounded-xl border border-slate-700/50 p-5"
        style="background-color: #1C2532;"
      >
        <div class="flex h-12 w-12 shrink-0 items-center justify-center rounded-xl bg-green-700">
          <CircleCheck :size="24" class="text-green-950" />
        </div>

        <div class="min-w-0 flex-1">
          <p class="text-xs text-slate-400">Tamamlanan</p>
          <p class="mt-1 text-2xl font-bold text-white">86</p>
          <p class="mt-1 text-xs text-slate-400">Tamamlanan işler</p>
        </div>

        <div class="shrink-0 self-end pb-1 text-xs font-medium text-green-400">
          ↑ 21%
        </div>
      </div>

    </div>

    <!-- Arama, filtreler ve tablo -->
    <div
      class="mt-6 min-w-0 rounded-lg border border-slate-700/50 p-3 sm:mt-8 sm:p-4"
      style="background-color: #1C2532;"
    >

      <!-- Filtre alanları -->
      <div class="grid grid-cols-1 gap-4 sm:grid-cols-2 xl:grid-cols-4">

        <!-- Arama -->
        <div class="relative min-w-0">
          <label for="table-search" class="mb-1 block text-xs text-gray-400">
            Arama
          </label>

          <input
            id="table-search"
            type="text"
            placeholder="Takım adı veya açıklama ara..."
            class="w-full rounded-xl border border-gray-700 bg-gray-800 py-3 pl-4 pr-10 text-sm text-white placeholder-gray-400 focus:outline-none focus:ring-1 focus:ring-blue-500"
          />

          <Search
            class="pointer-events-none absolute right-3 top-9 h-5 w-5 text-gray-400"
          />
        </div>

        <!-- Durum -->
        <div class="min-w-0">
          <label for="table-status" class="mb-1 block text-xs text-gray-400">
            Durum
          </label>

          <div class="relative">
            <select
              id="table-status"
              class="w-full appearance-none rounded-lg border border-gray-700 bg-gray-800 py-3 pl-3 pr-9 text-sm text-gray-200 focus:outline-none focus:ring-1 focus:ring-blue-500"
            >
              <option value="">Tümü</option>
              <option value="active">Aktif</option>
              <option value="passive">Pasif</option>
            </select>

            <ChevronDown
              class="pointer-events-none absolute right-3 top-1/2 h-4 w-4 -translate-y-1/2 text-gray-400"
            />
          </div>
        </div>

        <!-- Departman -->
        <div class="min-w-0">
          <label for="table-department" class="mb-1 block text-xs text-gray-400">
            Departman
          </label>

          <div class="relative">
            <select
              id="table-department"
              class="w-full appearance-none rounded-lg border border-gray-700 bg-gray-800 py-3 pl-3 pr-9 text-sm text-gray-200 focus:outline-none focus:ring-1 focus:ring-blue-500"
            >
              <option value="">Tümü</option>
            </select>

            <ChevronDown
              class="pointer-events-none absolute right-3 top-1/2 h-4 w-4 -translate-y-1/2 text-gray-400"
            />
          </div>
        </div>

        <!-- Filtreleri temizle -->
        <div class="flex min-w-0 items-end">
          <button
            type="button"
            class="flex min-h-11 w-full items-center justify-center rounded-lg border border-gray-700 bg-gray-800 px-3 py-3 text-sm text-white transition-colors hover:bg-gray-700"
          >
            <RefreshCcw :size="18" class="mr-2 shrink-0" />
            <span>Filtreleri Temizle</span>
          </button>
        </div>

      </div>

      <!-- Yalnızca tablo alanı yatay kaydırılır -->
      <div class="mt-5 w-full max-w-full overflow-x-auto rounded-xl">
        <table
          class="w-full min-w-[650px] border-separate border-spacing-0 text-sm sm:text-base"
          style="background-color: #1C2532;"
        >
          <thead class="text-white" style="background-color: #252D3B;">
            <tr>
              <th
                v-for="column in columns"
                :key="column.key"
                class="whitespace-nowrap p-3 text-left sm:p-4"
              >
                {{ column.label }}
              </th>

              <th class="whitespace-nowrap p-3 text-left sm:p-4">
                İşlemler
              </th>
            </tr>
          </thead>

          <tbody class="text-white">
            <tr
              v-for="item in items"
              :key="item.id"
              class="transition-colors duration-200 hover:bg-slate-800/40"
            >
              <td
                v-for="column in columns"
                :key="column.key"
                class="border-b border-gray-700/60 p-3 sm:p-4"
              >
                <slot :name="`cell-${column.key}`" :item="item">
                  {{ item[column.key] }}
                </slot>
              </td>

              <td class="whitespace-nowrap border-b border-gray-700/60 p-3 sm:p-4">
                <slot name="actions" :item="item"></slot>
              </td>
            </tr>

            <tr v-if="items.length === 0">
              <td
                :colspan="columns.length + 1"
                class="p-8 text-center text-slate-400"
              >
                Gösterilecek kayıt bulunamadı.
              </td>
            </tr>
          </tbody>
        </table>
      </div>

      <!-- Kayıt bilgisi -->
      <div class="border-t border-gray-700">
        <p class="p-4 text-sm text-slate-400">
          Toplam {{ items.length }} kayıt
        </p>
      </div>

    </div>
  </div>
</template>
