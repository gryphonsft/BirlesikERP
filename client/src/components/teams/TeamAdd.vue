
<script setup>
import { ref } from "vue";
import {
  ArrowLeft,
  FileText,
  Handshake,
  Save,
  Users,
  Building2,
} from "@lucide/vue";

const emit = defineEmits(["save"]);

defineProps({
  departments: {
    type: Array,
    default: () => [],
  },
});

const team = ref({
  name: "",
  description: "",
  departmentId: null,
});

function submit() {
  emit("save", { ...team.value });

  team.value = {
    name: "",
    description: "",
    departmentId: null,
  };
}
</script>

<template>
  <div class="w-full min-w-0">
    <form @submit.prevent="submit">
      <!-- Üst başlık ve işlemler -->
      <header
        class="flex flex-col gap-4 border-b border-slate-700 p-4 sm:p-6 lg:flex-row lg:items-center lg:justify-between lg:px-8"
      >
        <div class="flex min-w-0 items-center gap-3">
          <RouterLink
            to="/teams"
            aria-label="Takımlara geri dön"
            class="flex shrink-0 items-center justify-center rounded-lg border border-slate-600 p-2 text-white transition hover:bg-slate-600"
          >
            <ArrowLeft :size="24" />
          </RouterLink>

          <h1 class="text-2xl font-bold text-white sm:text-3xl">
            Takım Ekle
          </h1>
        </div>

        <div class="flex flex-col gap-3 sm:flex-row sm:justify-end">
          <RouterLink
            to="/teams"
            class="inline-flex items-center justify-center rounded-lg bg-white px-6 py-3 text-slate-950 transition hover:bg-gray-200"
          >
            İptal
          </RouterLink>

          <button
            type="submit"
            class="inline-flex items-center justify-center rounded-lg bg-blue-600 px-6 py-3 text-white transition hover:bg-blue-700"
          >
            <Save :size="20" class="mr-2" />
            Kaydet
          </button>
        </div>
      </header>

      <!-- Adımlar -->
      <div class="p-4 sm:p-6 lg:p-8">
        <div class="rounded-xl p-5 sm:p-6" style="background-color: #1C2532;">
          <div class="grid grid-cols-1 gap-5 md:grid-cols-3 md:gap-4">
            <div class="flex min-w-0 items-center gap-3">
              <div
                class="flex h-10 w-10 shrink-0 items-center justify-center rounded-full bg-blue-600 font-semibold text-white"
              >
                1
              </div>

              <div class="min-w-0">
                <h3 class="font-semibold text-white">Takım Bilgileri</h3>
                <p class="text-sm text-slate-400">
                  Takım detaylarını girin
                </p>
              </div>
            </div>

            <div class="flex min-w-0 items-center gap-3">
              <div
                class="flex h-10 w-10 shrink-0 items-center justify-center rounded-full bg-blue-600 font-semibold text-white"
              >
                2
              </div>

              <div class="min-w-0">
                <h3 class="font-semibold text-white">Departman Seçimi</h3>
                <p class="text-sm text-slate-400">
                  Takımı departmana atayın
                </p>
              </div>
            </div>

            <div class="flex min-w-0 items-center gap-3">
              <div
                class="flex h-10 w-10 shrink-0 items-center justify-center rounded-full border border-slate-600 font-semibold text-slate-400"
              >
                3
              </div>

              <div class="min-w-0">
                <h3 class="font-semibold text-slate-400">Önizleme</h3>
                <p class="text-sm text-slate-500">
                  Bilgileri kontrol edin
                </p>
              </div>
            </div>
          </div>
        </div>
      </div>

      <!-- Form kartları -->
      <div
        class="grid w-full min-w-0 grid-cols-1 gap-5 px-4 pb-6 sm:px-6 lg:grid-cols-[minmax(0,3fr)_minmax(0,2fr)] lg:gap-8 lg:px-8"
      >
        <!-- Takım bilgileri -->
        <section
          class="min-w-0 rounded-xl shadow-2xl"
          style="background-color: #1C2532;"
        >
          <div class="flex items-center gap-3 px-5 pb-2 pt-6 sm:px-8">
            <div
              class="flex h-12 w-12 shrink-0 items-center justify-center rounded-full bg-blue-600 text-white sm:h-14 sm:w-14"
            >
              <Handshake :size="28" />
            </div>

            <div class="min-w-0">
              <h2 class="text-xl font-semibold text-white sm:text-2xl">
                Yeni Takım Bilgileri
              </h2>
              <p class="mt-1 text-sm text-gray-400">
                Takımınızın temel bilgilerini giriniz.
              </p>
            </div>
          </div>

          <div class="space-y-6 p-5 sm:space-y-8 sm:p-8">
            <div>
              <label for="team-name" class="mb-2 block text-white">
                Takım Adı
              </label>

              <div class="relative">
                <Users
                  :size="18"
                  class="absolute left-3 top-1/2 -translate-y-1/2 text-slate-400"
                />

                <input
                  id="team-name"
                  v-model="team.name"
                  type="text"
                  required
                  maxlength="100"
                  placeholder="Örnek: Backend Geliştirme Takımı"
                  class="w-full rounded-lg border border-slate-700 bg-[#18212F] py-3 pl-10 pr-4 text-white placeholder-slate-500 focus:border-blue-500 focus:outline-none focus:ring-2 focus:ring-blue-500/30"
                />
              </div>
            </div>

            <div>
              <label for="team-description" class="mb-2 block text-white">
                Açıklama
              </label>

              <div class="relative">
                <FileText
                  :size="18"
                  class="absolute left-3 top-4 text-slate-400"
                />

                <textarea
                  id="team-description"
                  v-model="team.description"
                  rows="6"
                  maxlength="1000"
                  placeholder="Takımın amacı, sorumlulukları ve kapsamı hakkında bilgi giriniz."
                  class="w-full resize-y rounded-lg border border-slate-700 bg-[#18212F] py-3 pl-10 pr-4 text-white placeholder-slate-500 focus:border-blue-500 focus:outline-none focus:ring-2 focus:ring-blue-500/30"
                ></textarea>
              </div>
            </div>
          </div>
        </section>

        <!-- Departman seçimi -->
        <section
          class="min-w-0 rounded-xl shadow-2xl"
          style="background-color: #1C2532;"
        >
          <div class="flex items-center gap-3 px-5 pb-2 pt-6 sm:px-8">
            <div
              class="flex h-12 w-12 shrink-0 items-center justify-center rounded-full bg-emerald-950 text-green-300 sm:h-14 sm:w-14"
            >
              <Building2 :size="28" />
            </div>

            <div class="min-w-0">
              <h2 class="text-xl font-semibold text-white sm:text-2xl">
                Departman Seç
              </h2>
              <p class="mt-1 text-sm text-gray-400">
                Takıma bir departman atamak için seçim yapınız.
              </p>
            </div>
          </div>

          <div class="space-y-3 p-4 sm:p-5">
            <p
              v-if="departments.length === 0"
              class="rounded-lg border border-slate-700 p-4 text-sm text-slate-400"
            >
              Henüz seçilebilecek bir departman bulunmuyor.
            </p>

            <button
              v-for="department in departments"
              :key="department.id"
              type="button"
              :aria-pressed="team.departmentId === department.id"
              @click="team.departmentId = department.id"
              class="flex w-full min-w-0 items-center justify-between gap-3 rounded-xl border p-3 text-left shadow transition sm:p-4"
              :class="
                team.departmentId === department.id
                  ? 'border-blue-500 bg-blue-600 text-white'
                  : 'border-slate-700 text-white hover:bg-slate-700'
              "
            >
              <div class="flex min-w-0 items-center gap-3">
                <div
                  class="flex h-11 w-11 shrink-0 items-center justify-center rounded-full bg-gray-800 sm:h-12 sm:w-12"
                >
                  <Building2 :size="24" />
                </div>

                <div class="flex min-w-0 flex-col">
                  <span class="break-words font-semibold">
                    {{ department.name }}
                  </span>

                  <span
                    v-if="department.description"
                    class="mt-1 break-words text-sm"
                    :class="
                      team.departmentId === department.id
                        ? 'text-blue-100'
                        : 'text-slate-400'
                    "
                  >
                    {{ department.description }}
                  </span>
                </div>
              </div>

              <span
                v-if="team.departmentId === department.id"
                class="shrink-0 text-lg"
                aria-hidden="true"
              >
                ✓
              </span>
            </button>
          </div>
        </section>
      </div>
    </form>
  </div>
</template>
