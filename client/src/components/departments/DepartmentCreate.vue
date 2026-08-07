<script setup>
import { ref } from "vue";
import { ArrowLeft, Building2 } from '@lucide/vue';

const emit = defineEmits(["save"]);

const department = ref({
    name: "",
    description: ""
});

function submit() {
    emit("save", department.value);

    department.value = {
        name: "",
        description: ""
    };
}
</script>
<template>
    <div>
        <form @submit.prevent="submit">
            <div class="flex items-center justify-between border-b p-8">
                <div class="flex items-center ml-10">
                    <RouterLink to="/departments"
                        class="text-white border rounded-lg p-2 hover:bg-slate-600 transition">
                        <ArrowLeft :size="30" />
                    </RouterLink>

                    <h1 class="text-white text-3xl ml-6">
                        Departman Ekle
                    </h1>
                </div>
                <div class="flex gap-6">
                    <RouterLink to="/departments" class="bg-white p-3 rounded-lg px-6">
                        İptal
                    </RouterLink>
                    <button to="" class="bg-white p-3 rounded-lg px-6 mr-35">
                        Kaydet
                    </button>
                </div>
            </div>

            <div class="flex justify-around gap-4">



                <div class="flex w-130 h-140 p-2 justify-center mt-12">
                    <div class="w-full max-w-4xl bg-slate-800 rounded-xl shadow-lg border border-slate-700">

                        <div class="border-b border-slate-700 px-8 py-5">
                            <div class="flex">
                                <Building2 :size="30" class="text-white" />
                                <h2 class="text-2xl ml-2 font-semibold text-white">
                                    Yeni Departman
                                </h2>
                            </div>
                        </div>

                        <div class="flex justify-center p-8">
                            <div>
                                <h1 class="text-white">Departman Adı</h1>
                                <input v-model="department.name"
                                    class="bg-white rounded p-2 mt-0.5 border-amber-50 w-100"
                                    placeholder="Departman adı giriniz" type="text">
                            </div>
                        </div>
                        <div class="flex justify-center p-8">
                            <div>
                                <h1 class="text-white">Açıklama</h1>
                                <input v-model="department.description"
                                    class="bg-white rounded p-2 mt-0.5 border-amber-50 w-100"
                                    placeholder="Açıklamayı giriniz" type="text">
                            </div>
                        </div>

                    </div>
                </div>

                <div class="flex justify-center mt-12">
                    <div class="w-full max-w-4xl bg-slate-800 rounded-xl shadow-lg border border-slate-700">

                        <div class="border-b border-slate-700 px-8 py-5">
                            <h2 class="text-2xl font-semibold text-white">
                                Yeni Departman
                            </h2>
                            <p class="text-slate-400 mt-1">
                                Yeni bir departman oluşturmak için bilgileri girin.
                            </p>
                        </div>

                        <div class="p-8">
                            <!-- Form buraya gelecek -->
                        </div>

                    </div>
                </div>
            </div>
        </form>
    </div>

</template>