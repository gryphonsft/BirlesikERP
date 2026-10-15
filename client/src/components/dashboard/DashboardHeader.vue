
<template>
  <header
    class="flex w-full min-w-0 flex-col gap-4 border-b-2 border-gray-700 px-4 py-4 sm:px-6 sm:py-5 lg:flex-row lg:items-center lg:justify-between lg:gap-6 lg:py-7"
    style="background-color: #111827;"
  >
    <!-- Arama alanı -->
    <div class="relative w-full min-w-0 lg:max-w-80">
      <div
        class="pointer-events-none absolute inset-y-0 left-0 flex items-center pl-3"
      >
        <svg
          class="h-5 w-5 text-gray-400"
          fill="none"
          stroke="currentColor"
          viewBox="0 0 24 24"
        >
          <path
            stroke-linecap="round"
            stroke-linejoin="round"
            stroke-width="2"
            d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z"
          />
        </svg>
      </div>

      <input
        type="text"
        placeholder="Search"
        class="w-full rounded-xl border border-gray-700 bg-gray-800 py-2.5 pl-10 pr-4 text-sm text-gray-200 placeholder-gray-500 transition focus:border-emerald-500 focus:outline-none focus:ring-2 focus:ring-emerald-500/50"
      />
    </div>

    <!-- Sağ taraftaki butonlar -->
    <div
      class="flex w-full min-w-0 items-center justify-end gap-2 sm:gap-3 lg:w-auto"
    >
      <button
        type="button"
        aria-label="Takvim"
        class="flex h-10 w-10 shrink-0 items-center justify-center rounded-full bg-gray-800 text-gray-300 transition hover:bg-gray-700"
      >
        <svg
          class="h-5 w-5"
          fill="none"
          stroke="currentColor"
          viewBox="0 0 24 24"
        >
          <path
            stroke-linecap="round"
            stroke-linejoin="round"
            stroke-width="2"
            d="M8 7V3m8 4V3m-9 8h10M5 21h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v12a2 2 0 002 2z"
          />
        </svg>
      </button>

      <button
        type="button"
        aria-label="Bildirimler"
        class="relative flex h-10 w-10 shrink-0 items-center justify-center rounded-full bg-gray-800 text-gray-300 transition hover:bg-gray-700"
      >
        <svg
          class="h-5 w-5"
          fill="none"
          stroke="currentColor"
          viewBox="0 0 24 24"
        >
          <path
            stroke-linecap="round"
            stroke-linejoin="round"
            stroke-width="2"
            d="M15 17h5l-1.405-1.405A2.032 2.032 0 0118 14.158V11a6.002 6.002 0 00-4-5.659V5a2 2 0 10-4 0v.341C7.67 6.165 6 8.388 6 11v3.159c0 .538-.214 1.055-.595 1.436L4 17h5m6 0v1a3 3 0 11-6 0v-1m6 0H9"
          />
        </svg>
        <span
          class="absolute -right-0.5 -top-0.5 flex h-4 w-4 items-center justify-center rounded-full bg-red-500 text-[10px] font-bold text-white"
        >
          1
        </span>
      </button>

      <button
        type="button"
        aria-label="Mesajlar"
        class="relative flex h-10 w-10 shrink-0 items-center justify-center rounded-full bg-gray-800 text-gray-300 transition hover:bg-gray-700"
      >
        <svg
          class="h-5 w-5"
          fill="none"
          stroke="currentColor"
          viewBox="0 0 24 24"
        >
          <path
            stroke-linecap="round"
            stroke-linejoin="round"
            stroke-width="2"
            d="M15 17h5l-1.405-1.405A2.032 2.032 0 0118 14.158V11a6.002 6.002 0 00-4-5.659V5a2 2 0 10-4 0v.341C7.67 6.165 6 8.388 6 11v3.159c0 .538-.214 1.055-.595 1.436L4 17h5m6 0v1a3 3 0 11-6 0v-1m6 0H9"
          />
        </svg>
        <span
          class="absolute -right-0.5 -top-0.5 flex h-4 w-4 items-center justify-center rounded-full bg-red-500 text-[10px] font-bold text-white"
        >
          1
        </span>
      </button>

      <button
        type="button"
        aria-label="Diğer bildirimler"
        class="relative flex h-10 w-10 shrink-0 items-center justify-center rounded-full bg-gray-800 text-gray-300 transition hover:bg-gray-700"
      >
        <svg
          class="h-5 w-5"
          fill="none"
          stroke="currentColor"
          viewBox="0 0 24 24"
        >
          <path
            stroke-linecap="round"
            stroke-linejoin="round"
            stroke-width="2"
            d="M15 17h5l-1.405-1.405A2.032 2.032 0 0118 14.158V11a6.002 6.002 0 00-4-5.659V5a2 2 0 10-4 0v.341C7.67 6.165 6 8.388 6 11v3.159c0 .538-.214 1.055-.595 1.436L4 17h5m6 0v1a3 3 0 11-6 0v-1m6 0H9"
          />
        </svg>
        <span
          class="absolute -right-0.5 -top-0.5 flex h-4 w-4 items-center justify-center rounded-full bg-red-500 text-[10px] font-bold text-white"
        >
          1
        </span>
      </button>

      <!-- Profil -->
      <button
        type="button"
        aria-label="Kullanıcı profili"
        class="h-10 w-10 shrink-0 overflow-hidden rounded-full border-2 border-gray-700 transition hover:border-emerald-500"
      >
        <img
          src="https://i.pravatar.cc/100"
          alt="User"
          class="h-full w-full object-cover"
        />
      </button>
    </div>
  </header>
</template>
