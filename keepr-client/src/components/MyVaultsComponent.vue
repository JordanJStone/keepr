<template>
  <div class="col-3">
    <router-link :to="{ name: 'SingleVaultPage', params: { id: vaultProp.id}}">
      <div class="myVaultsComponent card mb-2 background">
        <h4>
          {{ vaultProp.name }}
        </h4>
      </div>
    </router-link>
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
.background {
background-image: linear-gradient(white, #e6fff7);
}

</style>
