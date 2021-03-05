<template>
  <div class="SingleVaultOfKeepsComponent card mb-2">
    <img :src="keepProp.img" class="img-fluid">
    <h4>
      {{ keepProp.name }}
      <i class="fa fa-trash-o text-danger" @click="removeKeepFromVault"></i>
    </h4>
  </div>
</template>

<script>
import { reactive } from 'vue'
import { useRoute } from 'vue-router'
import { vaultKeepsService } from '../services/VaultKeepsService'
import { logger } from '../utils/Logger'
// import { AppState } from '../AppState'
export default {
  name: 'SingleVaultOfKeepsComponent',
  props: {
    keepProp: { type: Object, required: true }
  },
  setup(props) {
    const route = useRoute()
    const state = reactive({
    })
    return {
      state,
      removeKeepFromVault() {
        try {
          vaultKeepsService.removeKeepFromVault(route.params.id)
        } catch (error) {
          logger.log(error)
        }
      }
    }
  }
}
</script>

<style scoped>
/* .imageFit{
  height: 100%;
  width: 100%;
  object-fit: contain;
  } */

</style>
