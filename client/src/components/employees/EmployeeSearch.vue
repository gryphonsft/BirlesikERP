<template>
  <div class="search-container">
    <svg
      class="search-icon"
      xmlns="http://www.w3.org/2000/svg"
      width="18"
      height="18"
      fill="none"
      viewBox="0 0 24 24"
      stroke="currentColor"
    >
      <path
        stroke-linecap="round"
        stroke-linejoin="round"
        stroke-width="2"
        d="M21 21l-4.35-4.35m1.1-5.15a6.75 6.75 0 11-13.5 0 6.75 6.75 0 0113.5 0z"
      />
    </svg>

    <input
      :value="modelValue"
      @input="$emit('update:modelValue', $event.target.value)"
      type="text"
      placeholder="Çalışan ara..."
    />
  </div>
</template>

<script setup>
defineProps({
  modelValue: String
})

defineEmits(["update:modelValue"])
</script>

<style scoped>
.search-container {
  position: relative;
  width: 320px;
}

.search-container input {
  width: 100%;
  height: 42px;
  padding: 0 15px 0 42px;
  border: 1px solid #d6d6d6;
  border-radius: 8px;
  outline: none;
  font-size: 15px;
  transition: .2s;
}

.search-container input:focus {
  border-color: #0d6efd;
  box-shadow: 0 0 0 3px rgba(13,110,253,.15);
}

.search-icon {
  position: absolute;
  left: 13px;
  top: 50%;
  transform: translateY(-50%);
  color: #777;
}
</style>