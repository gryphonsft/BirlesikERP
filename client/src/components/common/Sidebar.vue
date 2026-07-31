<template>

    <aside class="w-72 bg-gray-800 border-r-2 border-gray-700 text-white flex flex-col" style="background-color: #24242E;">

        <div class="p-8">

            <h1 class="text-3xl font-bold">
                BirleşikERP
            </h1>

        </div>

        <nav class="flex-1 p-6 space-y-2 items-center">

            <RouterLink to="/"  class="flex items-center rounded-lg px-4 py-3 hover:bg-slate-800">

                Dashboard

            </RouterLink>

            <RouterLink to="/employees" class="flex items-center rounded-lg px-4 py-3 hover:bg-slate-800">

                Çalışanlar

            </RouterLink>

            <RouterLink to="/departments" class="flex items-center rounded-lg px-4 py-3 hover:bg-slate-800">

                Departmanlar

            </RouterLink>

        </nav>

    </aside>

</template>
