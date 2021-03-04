<template>
  <div class="myVaultsComponent card mb-2 imageFit" :style="{backgroundImage:`url(${vaultProp.img})`}">
    <h4>
      {{ vaultProp.name }}
    </h4>
  </div>
</template>

<script>
import { reactive } from 'vue'
// import { AppState } from '../AppState'
export default {
  name: 'MyVaultsComponent',
  props: {
    vaultProp: { type: Object, required: true }
  },
  setup(props) {
    const state = reactive({
    })
    return { state }
  }
}
</script>

<style scoped>
.imageFit{
  height: 100%;
  width: 100%;
  object-fit: contain;
  }

</style>
