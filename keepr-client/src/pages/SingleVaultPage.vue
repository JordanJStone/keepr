<template>
  <div class="container-fluid">
    <div class="row">
      <h2>{{ activeVault.name }}&nbsp;&nbsp;<i class="fa fa-trash-o text-danger" aria-hidden="true" @click="deleteVault"></i></h2>
    </div>
    <div class="row">
      <div class="col-12 masonry">
        <SingleVaultOfKeeps-component class="item" v-for="r in state.keeps" :key="r.id" :keep-prop="r">
        </SingleVaultOfKeeps-component>
      </div>
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
      try {
        await vaultsService.getActiveVault(route.params.id)
      } catch (error) {
        logger.log(error)
      }
    })
    return {
      state,
      activeVault: computed(() => AppState.activeVault),
      async deleteVault() {
        try {
          await vaultsService.deleteVault(route.params.id)
        } catch (error) {
          logger.log(error)
        }
      }
    }
  }
}
</script>

<style scoped>
.masonry {
  column-count: 4;
  column-gap: 1em;
}

.masonry-custom {
  column-count: 1;
  column-gap: 1em;
}

.item { /* Masonry bricks or child elements */
  background-color: #eee;
  display: inline-block;
  margin: 0 0 1em;
  width: 100%;
  /* display: inline-block; */
}

</style>
