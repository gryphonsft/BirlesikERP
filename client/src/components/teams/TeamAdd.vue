<script setup>
import { ref } from "vue";
import { ArrowLeft, FileText, Handshake, Save, Users, Building2 } from '@lucide/vue';

const emit = defineEmits(["save"]);

const props = defineProps({
    departments: Array
});

const team = ref({
    name: "",
    description: "",
    departmentId: null
});

function submit() {
    emit("save", team.value);

    team.value = {
        name: "",
        description: ""
    };
}
</script>
<template>
    <div>
        <form @submit.prevent="submit">
            <div class="flex items-center justify-between border-b border-slate-700 p-8">
                <div class="flex items-center ml-10">
                    <RouterLink to="/departments"
                        class="text-white border rounded-lg p-2 hover:bg-slate-600 transition">
                        <ArrowLeft :size="30" />
                    </RouterLink>

                    <h1 class="text-white text-3xl ml-6">
                        Takım Ekle
                    </h1>
                </div>
                <div class="flex gap-6">
                    <RouterLink to="/teams" class="bg-white p-3 rounded-lg px-6">
                        İptal
                    </RouterLink>
                    <button class="flex items-center text-white bg-blue-600 p-3 rounded-lg px-6 mr-35">
                        <Save class="mr-2" />
                        Kaydet
                    </button>
                </div>
            </div>

            <div class="p-8 space-y-8">
                <div class=" rounded-xl p-6" style="background-color: #141C2F;">

                    <div class="grid grid-cols-3">

                        <div class="flex items-center gap-4">
                            <div
                                class="w-10 h-10 rounded-full bg-blue-600 text-white flex items-center justify-center font-semibold">
                                1
                            </div>

                            <div>
                                <h3 class="text-white font-semibold">
                                    Takım Bilgileri
                                </h3>

                                <p class="text-slate-400 text-sm">
                                    Takım detaylarını girin
                                </p>
                            </div>
                        </div>

                        <div class="flex items-center gap-4">
                            <div
                                class="w-10 h-10 rounded-full bg-blue-600 text-white flex items-center justify-center font-semibold">
                                2
                            </div>

                            <div>
                                <h3 class="text-white font-semibold">
                                    Departman Seçimi
                                </h3>

                                <p class="text-slate-400 text-sm">
                                    Takımı departmana atayın
                                </p>
                            </div>
                        </div>

                        <!-- Adım 3 -->
                        <div class="flex items-center gap-4">
                            <div
                                class="w-10 h-10 rounded-full border border-slate-600 text-slate-400 flex items-center justify-center font-semibold">
                                3
                            </div>

                            <div>
                                <h3 class="text-slate-400 font-semibold">
                                    Önizleme
                                </h3>

                                <p class="text-slate-500 text-sm">
                                    Bilgileri kontrol edin
                                </p>
                            </div>
                        </div>

                    </div>

                </div>
            </div>

            <div class="flex w-full h-full gap-8 p-8">

                <div class="basis-3/5 rounded-xl shadow-2xl" style="background-color: #141C2F;">

                    <div class="px-8 py-5 mt-4">
                        <div class="flex items-center gap-2">
                            <div
                                class="w-15 h-15 rounded-full bg-blue-600 text-white flex items-center justify-center font-semibold">
                                <Handshake :size="30" class="text-white-600" />
                            </div>

                            <div class="ml-1">
                                <h2 class="text-3xl  text-white">
                                    Yeni Takım Bilgileri
                                </h2>
                                <p class="text-gray-500">
                                    Takımınızın temel bilgilerini giriniz.
                                </p>
                            </div>

                        </div>
                    </div>

                    <div class="p-8 space-y-8">

                        <div>
                            <label class="block text-white mb-2">
                                Takım Adı
                            </label>

                            <div class="relative">
                                <Users :size="18" class="absolute left-3 top-1/2 -translate-y-1/2 text-slate-400" />

                                <input v-model="team.name" type="text" placeholder="Örnek: Backend Geliştirme Takımı"
                                    class="w-full border border-slate-700 rounded-lg pl-10 pr-4 py-3 text-white" />
                            </div>
                        </div>

                        <div>
                            <label class="block text-white mb-2">
                                Açıklama
                            </label>
                            <div class="relative">
                                <FileText :size="18" class="absolute left-3 top-1/8 -translate-y-1/2 text-slate-400" />
                                <textarea v-model="team.description" rows="7"
                                    placeholder="Takımın amacı, sorumlulukları ve kapsamı hakkında bilgi giriniz."
                                    class="w-full border border-slate-700 rounded-lg pl-10 pr-4 py-3 text-white"></textarea>
                            </div>

                        </div>

                    </div>

                </div>

                <div class="basis-2/5 rounded-xl shadow-2xl" style="background-color: #141C2F;">

                    <div class="px-8 py-5 mt-4">
                        <div class="flex items-center gap-2">
                            <div
                                class="w-15 h-15 rounded-full bg-emerald-950 text-white flex items-center justify-center font-semibold">
                                <Building2 :size="30" class="text-green-300" />
                            </div>

                            <div class="ml-1">
                                <h2 class="text-3xl  text-white">
                                    Yeni Departman Seç
                                </h2>
                                <p class="text-gray-500">
                                    Takıma bir departman atamak için seçim yapınız.
                                </p>
                            </div>

                        </div>
                    </div>

                    <div class="p-4 space-y-4">

                        <button type="button" v-for="department in departments" :key="department.id"
                            @click="team.departmentId = department.id"
                            class="w-full rounded-xl flex justify-between shadow items-center p-4 transition-all border"
                            :class="team.departmentId === department.id
                                ? 'bg-blue-600 text-white border-blue-500'
                                : 'text-white border-slate-700 hover:bg-slate-700'
                                ">

                            <div class="flex items-center gap-3">
                                <div class="w-15 h-15 rounded-full bg-gray-800 flex items-center justify-center">
                                    <Building2 :size="30"  />
                                </div>

                                <div class="flex flex-col">
                                    <span class="font-semibold">
                                        {{ department.name }}
                                    </span>

                                    <span class="text-sm text-slate-400">
                                        {{ department.description }}
                                    </span>
                                </div>
                            </div>
                            <span v-if="team.departmentId === department.id" class="text-lg">
                                ✓
                            </span>

                        </button>

                    </div>

                </div>

            </div>
        </form>
    </div>

</template>