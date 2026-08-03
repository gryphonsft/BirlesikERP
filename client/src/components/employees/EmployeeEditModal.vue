<script setup>
const props = defineProps({
  show: Boolean,
  employee: Object,
});

const emit = defineEmits(["close", "save"]);
</script>

<template>
  <div
    v-if="show"
    class="fixed inset-0 z-50 flex items-center justify-center bg-slate-900/60 backdrop-blur-sm p-4"
  >
    <div
      class="w-full max-w-5xl bg-white rounded-2xl shadow-2xl overflow-hidden"
    >
      <!-- Header -->
      <div
        class=" text-white px-8 py-6 flex justify-between items-center" style="background-color: #26262A;"
      >
        <div>
          <h2 class="text-2xl font-bold">Çalışanı Düzenle</h2>
          <p class="text-blue-100 mt-1 text-sm">
            Personel bilgilerini güncelleyebilirsiniz.
          </p>
        </div>

        <button
          @click="emit('close')"
          class="text-3xl hover:text-red-300 transition"
        >
          ×
        </button>
      </div>

      <div
        v-if="employee"
        class="p-8 space-y-8 max-h-[80vh] overflow-y-auto bg-gray-50"
      >
        <!-- Kişisel Bilgiler -->
        <section class="bg-white rounded-xl border shadow-sm p-6">
          <h3 class="text-lg font-semibold text-gray-700 mb-6 border-b pb-3">
            👤 Kişisel Bilgiler
          </h3>

          <div class="grid md:grid-cols-2 gap-6">
            <div>
              <label class="block text-sm font-semibold text-gray-600 mb-2">
                Ad
              </label>

              <input
                v-model="employee.firstName"
                class="w-full rounded-lg border border-gray-300 px-4 py-2.5 focus:ring-2 focus:ring-blue-500 focus:border-blue-500 outline-none transition"
              />
            </div>

            <div>
              <label class="block text-sm font-semibold text-gray-600 mb-2">
                Soyad
              </label>

              <input
                v-model="employee.lastName"
                class="w-full rounded-lg border border-gray-300 px-4 py-2.5 focus:ring-2 focus:ring-blue-500 focus:border-blue-500 outline-none transition"
              />
            </div>

            <div>
              <label class="block text-sm font-semibold text-gray-600 mb-2">
                Yaş
              </label>

              <input
                type="number"
                v-model="employee.age"
                class="w-full rounded-lg border border-gray-300 px-4 py-2.5 focus:ring-2 focus:ring-blue-500 focus:border-blue-500 outline-none transition"
              />
            </div>

            <div>
              <label class="block text-sm font-semibold text-gray-600 mb-2">
                Doğum Tarihi
              </label>

              <input
                type="date"
                v-model="employee.birthDate"
                class="w-full rounded-lg border border-gray-300 px-4 py-2.5 focus:ring-2 focus:ring-blue-500 focus:border-blue-500 outline-none transition"
              />
            </div>
          </div>
        </section>

        <!-- İletişim -->
        <section class="bg-white rounded-xl border shadow-sm p-6">
          <h3 class="text-lg font-semibold text-gray-700 mb-6 border-b pb-3">
            📞 İletişim Bilgileri
          </h3>

          <div class="grid md:grid-cols-2 gap-6">
            <div>
              <label class="block text-sm font-semibold text-gray-600 mb-2">
                Email
              </label>

              <input
                v-model="employee.email"
                class="w-full rounded-lg border border-gray-300 px-4 py-2.5 focus:ring-2 focus:ring-blue-500 focus:border-blue-500 outline-none transition"
              />
            </div>

            <div>
              <label class="block text-sm font-semibold text-gray-600 mb-2">
                Telefon
              </label>

              <input
                v-model="employee.phone"
                class="w-full rounded-lg border border-gray-300 px-4 py-2.5 focus:ring-2 focus:ring-blue-500 focus:border-blue-500 outline-none transition"
              />
            </div>

            <div class="md:col-span-2">
              <label class="block text-sm font-semibold text-gray-600 mb-2">
                Şehir
              </label>

              <input
                v-model="employee.city"
                class="w-full rounded-lg border border-gray-300 px-4 py-2.5 focus:ring-2 focus:ring-blue-500 focus:border-blue-500 outline-none transition"
              />
            </div>
          </div>
        </section>

        <!-- Şirket -->
        <section class="bg-white rounded-xl border shadow-sm p-6">
          <h3 class="text-lg font-semibold text-gray-700 mb-6 border-b pb-3">
            🏢 Şirket Bilgileri
          </h3>

          <div class="grid md:grid-cols-3 gap-6">
            <div>
              <label class="block text-sm font-semibold text-gray-600 mb-2">
                Departman
              </label>

              <input
                v-model="employee.departmentName"
                readonly
                class="w-full rounded-lg bg-gray-100 border border-gray-200 px-4 py-2.5 text-gray-600"
              />
            </div>

            <div>
              <label class="block text-sm font-semibold text-gray-600 mb-2">
                Takım
              </label>

              <input
                v-model="employee.teamName"
                readonly
                class="w-full rounded-lg bg-gray-100 border border-gray-200 px-4 py-2.5 text-gray-600"
              />
            </div>

            <div>
              <label class="block text-sm font-semibold text-gray-600 mb-2">
                Pozisyon
              </label>

              <input
                v-model="employee.positionName"
                readonly
                class="w-full rounded-lg bg-gray-100 border border-gray-200 px-4 py-2.5 text-gray-600"
              />
            </div>
          </div>
        </section>

        <!-- Sistem -->
        <section class="bg-white rounded-xl border shadow-sm p-6">
          <h3 class="text-lg font-semibold text-gray-700 mb-6 border-b pb-3">
            ⚙️ Sistem Bilgileri
          </h3>

          <div class="grid md:grid-cols-2 gap-6">
            <div>
              <label class="block text-sm font-semibold text-gray-600 mb-2">
                Durum
              </label>

              <select
                v-model="employee.isActive"
                class="w-full rounded-lg border border-gray-300 px-4 py-2.5 focus:ring-2 focus:ring-blue-500 focus:border-blue-500 outline-none transition"
              >
                <option :value="true">Aktif</option>
                <option :value="false">Pasif</option>
              </select>
            </div>

            <div>
              <label class="block text-sm font-semibold text-gray-600 mb-2">
                Oluşturulma Tarihi
              </label>

              <input
                :value="new Date(employee.createdAt).toLocaleString('tr-TR')"
                readonly
                class="w-full rounded-lg bg-gray-100 border border-gray-200 px-4 py-2.5 text-gray-600"
              />
            </div>
          </div>
        </section>

        <!-- Footer -->
        <div class="flex justify-end gap-4 pt-2">
          <button
            @click="emit('close')"
            class="px-6 py-3 rounded-lg border border-gray-300 bg-white hover:bg-gray-100 transition font-medium"
          >
            İptal
          </button>

          <button
            @click="emit('save', employee)"
            class="px-6 py-3 rounded-lg bg-blue-600 text-white hover:bg-blue-700 shadow-md hover:shadow-lg transition font-semibold"
          >
            Kaydet
          </button>
        </div>
      </div>
    </div>
  </div>
</template>