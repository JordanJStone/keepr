<template>
  <div class="SingleVaultOfKeepsComponent card mb-2">
    <img :src="keepProp.img" class="img-fluid">
    <h4 class="textPosition text-white">
      {{ keepProp.name }}
      <i class="fa fa-trash-o text-danger ml-3" @click="removeKeepFromVault"></i>
      <i class="fa fa-user ml-5 pl-5" aria-hidden="true"></i>
    </h4>
  </div>
</template>

<script>
import { reactive, computed } from 'vue'
// import { useRoute } from 'vue-router'
import { AppState } from '../AppState'
import { vaultKeepsService } from '../services/VaultKeepsService'
import { logger } from '../utils/Logger'
// import { AppState } from '../AppState'
export default {
  name: 'SingleVaultOfKeepsComponent',
  props: {
    keepProp: { type: Object, required: true }
  },
  setup(props) {
    // const route = useRoute()
    const state = reactive({
      keeps: computed(() => AppState.singleVaultKeeps)
    })
    return {
      state,
      removeKeepFromVault() {
        try {
          vaultKeepsService.removeKeepFromVault(props.keepProp)
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

.SingleVaultOfKeepsComponent {
  position: relative;
}

.textPosition {
  position: absolute;
  bottom: 0px;
  left: 4px;
  font-size: 18px;
}

</style>
