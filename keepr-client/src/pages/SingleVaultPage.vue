<template>
  <div class="container-fluid">
    <div class="row">
      test
    </div>
  </div>
</template>

<script>
import { computed, reactive, onMounted } from 'vue'
import { AppState } from '../AppState'
import { useRoute } from 'vue-router'
import { logger } from '../utils/Logger'
import { vaultsService } from '../services/VaultsService'
export default {
  name: 'SingleVaultPage',
  setup() {
    const route = useRoute()
    const state = reactive({
      keeps: computed(() => AppState.singleVaultKeeps)
    })
    onMounted(async() => {
      try {
        await vaultsService.getAllKeeps(route.params.id)
      } catch (error) {
        logger.log(error)
      }
    })
    return {
      state
    }
  }
}
</script>

<style scoped>

</style>
